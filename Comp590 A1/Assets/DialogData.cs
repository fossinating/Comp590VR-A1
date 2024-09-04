

using Unity.VisualScripting;
using UnityEngine;

public abstract class DialogNode
{
    private readonly string text;
    private readonly string speaker;

    protected DialogNode(string speaker, string text)
    {
        this.text = text;
        this.speaker = speaker;
    }

    public string getText() { return text; }
    public string getSpeaker() { return speaker; }

    public abstract bool OnEnd(DialogController controller);
}

public class DialogLinearNode : DialogNode
{
    private readonly DialogNode nextNode;
    public DialogLinearNode(string speaker, string text, DialogNode nextNode) : base(speaker, text)
    {
        this.nextNode = nextNode;
    }

    public override bool OnEnd(DialogController controller)
    {
        controller.PlayDialog(nextNode);
        return true;
    }
}

public class DialogChoiceNode : DialogNode
{
    private readonly DialogOption[] dialogOptions;
    public DialogChoiceNode(string speaker, string text, DialogOption[] options): base(speaker, text)
    {
        this.dialogOptions = options;
    }
    public DialogOption[] getDialogOptions() { return dialogOptions; }

    public override bool OnEnd(DialogController controller)
    {
        controller.PlayDialog(this.dialogOptions[controller.getDialogSelectionIndex()].getNextNode());
        return true;
    }
}

public class DialogMessageNode : DialogNode
{
    private readonly string methodName;
    private readonly GameObject targetObject;
    
    public DialogMessageNode(string speaker, string text, string methodName, GameObject targetObject) : base(speaker, text)
    {
        this.methodName = methodName;
        this.targetObject = targetObject;
    }

    public override bool OnEnd(DialogController controller)
    {
        targetObject.BroadcastMessage(methodName);
        return false;
    }
}

public class DialogEndNode : DialogNode
{
    public DialogEndNode(string speaker, string text) : base(speaker, text) { }

    public override bool OnEnd(DialogController controller)
    {
        // the whole point is to do nothing, although I really don't see myself using this
        return false;
    }
}

public class DialogOption
{
    private readonly string text;

    private readonly DialogNode nextNode;

    public DialogOption(string text, DialogNode nextNode)
    {
        this.text = text;
        this.nextNode = nextNode;
    }

    public DialogOption(string text) : this(text, null) { }

    public string getText() { return text; }
    public DialogNode getNextNode() { return nextNode; }
}