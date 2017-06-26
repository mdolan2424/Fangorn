

function moveListBoxItem(leftID, rightID, isMoveAll)
{
    if (isMoveAll == true)
    {
        $("#" + leftID + " option").remove().appendTo("#" + rightID).removeAttr("selected");

    }

    else
    {

        $("#" + leftID + " option:selected").remove().appendTo("#" + rightID).removeAttr("selected");
    }
}