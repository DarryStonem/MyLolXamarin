# Updating ids for replacement

IdFile=$BITRISE_PROJECT_PATH/Source/MyLoL/Constants.cs

sed -i '' "s#LOLAPIKEY#$LOLAPIKEY#g" $IdFile

# Print out file for reference
cat $IdFile

echo "Updated id!"
