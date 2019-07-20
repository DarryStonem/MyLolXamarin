# Updating ids for replacement

IdFile=$BUILD_REPOSITORY_LOCALPATH/Source/MyLoL/Constants.cs

sed -i '' "s#LOLAPIKEY#$LOLAPIKEY#g" $IdFile
sed -i '' "s#APPCENTERIOS#$APPCENTERIOS#g" $IdFile
sed -i '' "s#APPCENTERANDROID#$APPCENTERANDROID#g" $IdFile

# Print out file for reference
cat $IdFile

echo "Updated id!"
