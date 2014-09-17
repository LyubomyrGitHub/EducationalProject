
$ProjectTemplatePathfor2012=(Get-ItemProperty HKCU:\Software\Microsoft\VisualStudio\11.0 UserProjectTemplatesLocation).UserProjectTemplatesLocation

$ProjectTemplatePathfor2010=(Get-ItemProperty HKCU:\Software\Microsoft\VisualStudio\10.0 UserProjectTemplatesLocation).UserProjectTemplatesLocation

# source and destination directory
$src_dir = ".\lib"

# list of files from source directory that I want to copy to destination folder
# unconditionally
$file_list = "JqueryMVCBindData.zip"

$dst_dir = $ProjectTemplatePathfor2012 #"C:\Anusha\Personal\HT\Test\"
# Copy each file unconditionally (regardless of whether or not the file is there
foreach ($file in $file_list)
{
  Copy-Item $src_dir$file $dst_dir
}

$dst_dir = $ProjectTemplatePathfor2010 #"C:\Anusha\Personal\HT\Test\"
# Copy each file unconditionally (regardless of whether or not the file is there
foreach ($file in $file_list)
{
  Copy-Item $src_dir$file $dst_dir
}