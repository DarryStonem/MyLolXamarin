# Updating ids for replacement

IdFile=Source/MyLoL/Constants.cs

sed -i '' "s#LOLAPIKEY#$LOLAPIKEY#g" $IdFile

# Print out file for reference
cat $IdFile

echo "Updated id!"
