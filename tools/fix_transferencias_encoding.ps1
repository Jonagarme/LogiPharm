$ErrorActionPreference = 'Stop'

function Remove-NullBytes([string]$path) {
    if (-not (Test-Path $path)) { return }
    $bytes = [System.IO.File]::ReadAllBytes($path)
    if ($bytes -notcontains 0) { return }

    $newBytes = New-Object byte[] ($bytes.Length - ($bytes | Where-Object { $_ -eq 0 }).Count)
    $i = 0
    foreach ($b in $bytes) {
        if ($b -ne 0) {
            $newBytes[$i] = $b
            $i++
        }
    }

    [System.IO.File]::WriteAllBytes($path, $newBytes)
}

$pathsToFix = @(
    'LogiPharm.Presentacion\FrmTransferencias.cs',
    'LogiPharm.Datos\DTransferencias.cs'
)

foreach ($p in $pathsToFix) {
    Remove-NullBytes $p
}

# Decode as Windows-1252 (common in legacy WinForms projects), then re-save as UTF-8 (with BOM)
$cp1252 = [System.Text.Encoding]::GetEncoding(1252)
$utf8Bom = New-Object System.Text.UTF8Encoding($true)

# --- Fix FrmTransferencias filter block (avoid accented comparisons) ---
$frmPath = 'LogiPharm.Presentacion\FrmTransferencias.cs'
if (Test-Path $frmPath) {
    $frmBytes = [System.IO.File]::ReadAllBytes($frmPath)
    $frmText = $cp1252.GetString($frmBytes)

    $pattern = 'string\s+filtroEstado\s*=\s*"";\s*if\s*\(cboEstado\.SelectedItem[\s\S]*?\}\s*\r?\n\s*\r?\n\s*DataTable\s+dt'

    $replacement = @(
        'string filtroEstado = "";',
        '                if (cboEstado.SelectedIndex > 0)',
        '                {',
        '                    // Mapeo por indice para evitar problemas de tildes/encoding.',
        '                    switch (cboEstado.SelectedIndex)',
        '                    {',
        '                        case 1: // Pendiente',
        '                            filtroEstado = "PENDIENTE";',
        '                            break;',
        '                        case 2: // En Transito',
        '                            filtroEstado = "EN_TRANSITO";',
        '                            break;',
        '                        case 3: // Recibida',
        '                            filtroEstado = "RECIBIDA";',
        '                            break;',
        '                        case 4: // Cancelada',
        '                            filtroEstado = "CANCELADA";',
        '                            break;',
        '                        default:',
        '                            filtroEstado = "";',
        '                            break;',
        '                    }',
        '                }',
        '',
        '                DataTable dt'
    ) -join "`r`n"

    $newFrmText = [System.Text.RegularExpressions.Regex]::Replace(
        $frmText,
        $pattern,
        $replacement,
        [System.Text.RegularExpressions.RegexOptions]::Singleline
    )

    if ($newFrmText -ne $frmText) {
        [System.IO.File]::WriteAllText($frmPath, $newFrmText, $utf8Bom)
        Write-Host "Updated: $frmPath"
    }
}

# --- Normalize obvious mojibake in DTransferencias ---
$dPath = 'LogiPharm.Datos\DTransferencias.cs'
if (Test-Path $dPath) {
    $dBytes = [System.IO.File]::ReadAllBytes($dPath)
    $dText = $cp1252.GetString($dBytes)

    $dText2 = $dText.Replace('atre1s', 'atras').Replace('recepci?', 'recepci')

    if ($dText2 -ne $dText) {
        [System.IO.File]::WriteAllText($dPath, $dText2, $utf8Bom)
        Write-Host "Updated: $dPath"
    }
}

Write-Host 'Done.'
