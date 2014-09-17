# source and destionation directory
$src_dir = "C:\Users\v-anvara\Desktop\"
$dst_dir = "C:\Anusha\Personal\HT\Test\"

# list of files from source directory that I want to copy to destination folder
# unconditionally
$file_list = "JqueryMVCList_Chandra.zip"

# Copy each file unconditionally (regardless of whether or not the file is there
foreach ($file in $file_list)
{
  Copy-Item $src_dir$file $dst_dir
}