using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;

public class DialogManager : MonoBehaviour {

    public Text dialogbox;
    public List<DialogLine> intro = new List<DialogLine>() {
        {new DialogLine(4,"Alright, Team N-Bomb!")},
        {new DialogLine(4,"Here're the new games that I've -")},
        {new DialogLine(2,"I vote to finally change our gang - name.")},
        {new DialogLine(4,"WHAAAAAT!?")},
        {new DialogLine(4,"The N - Bomb is the mightiest force in the universe!")},
        {new DialogLine(4,"We are like a huge explosion of Nickies!*flexes muscles *")},
        {new DialogLine(3,"I love your creativity, Nicky but there's something about the name…")},
        {new DialogLine(1,"True.")},
        {new DialogLine(4,"TRAITORS!OUR VENGEANCE SHALL STRIKE YOU IN THESE GAMES!RIGHT, STEPH ? !")},
        {new DialogLine(0,"Actually, I hate that name, too.")},
        {new DialogLine(4,"GRAAAAHHH!YOU MONSTERS!FINE!YOU COME UP WITH SOMETHING BETTER THEN!")},
        {new DialogLine(0,"Urvans")},
        {new DialogLine(4,"Oh, that's loads better.")},
        {new DialogLine(4,"Okay, AS I WAS SAYING…")},
        {new DialogLine(4,"The new games are in.")},
        {new DialogLine(4,"I will instruct you as we go through each one – any questions so far?")},
        {new DialogLine(2,"Yes.Will you get us in danger again?")},
        {new DialogLine(2,"I don't want to drag someone out of some goo again.")},
        {new DialogLine(4,"Pfsht.Stop being so boring!I thought you wanted to be great adventurers!")},
        {new DialogLine(1,"I like adventures.")},
        {new DialogLine(3,"YES!Me, too!But I don't want to hurt myself again…")},
        {new DialogLine(4,"Don't worry, little one, there is no danger involved this time!")},
        {new DialogLine(4,"I know all of you need training before going full N - bomb again, so today will be safe!")},
        {new DialogLine(4,"BUT NO SLACKING!")},
        {new DialogLine(4,"It will still be a test of skill and wits and only the bestest, most awesomest of us will get…")},
        {new DialogLine(4,"...THE PRIZE!!!")},
        {new DialogLine(3,"Wooooow!")},
        {new DialogLine(1,"YESSSS!")},
        {new DialogLine(0,"I will so win this over all of you.")},
        {new DialogLine(0,"You can already hang your heads in shame.")},
        {new DialogLine(3,"Yay!Go Steph, go Steph, GO!")},
        {new DialogLine(1,"No, I will win!The cosmonaut will be victorious!")},
        {new DialogLine(4,"YAHAHAHA!YOU FOOLS THINK YOU HAVE A CHANCE?!I'm afraid I will have to teach you all!")},
        {new DialogLine(2,"Say that to my badge, big boss.")},
        {new DialogLine(4,"PAH!I let you win last time!Now, everthing has changed!")},
        {new DialogLine(0,"Oh, you don't know how right you are…")}
    };
    private int currentLine = 0;

	// Use this for initialization
	void Start () {
    }

    void Update () {
	    if (Input.GetButtonDown("Fire1")) {
            // goto to next text
        }
        if (Input.GetButtonDown("Cancel")) {
            // skip texts
        }
    }

    [System.Serializable]
    public class DialogLine {
        [Range(0,4)]
        public int who;
        public string what;
        public float time;

        public DialogLine(int who, string what) {
            this.who = who;
            this.what = what;
            this.time = 2f;
        }
        public DialogLine(int who, string what, float time) : this(who, what) {
            this.time = time;
        }
    }

    //[CustomPropertyDrawer(typeof(DialogLine))]
    //public class DialogLineDrawer : PropertyDrawer {

    //    // Draw the property inside the given rect
    //    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    //        // Using BeginProperty / EndProperty on the parent property means that
    //        // prefab override logic works on the entire property.
    //        EditorGUI.BeginProperty(position, label, property);

    //        // Draw label
    //        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

    //        // Don't make child fields be indented
    //        var indent = EditorGUI.indentLevel;
    //        EditorGUI.indentLevel = 0;

    //        // Calculate rects
    //        var amountRect = new Rect(position.x, position.y, 30, position.height);
    //        var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
    //        var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

    //        // Draw fields - passs GUIContent.none to each so they are drawn without labels
    //        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("who"), GUIContent.none);
    //        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("what"), GUIContent.none);
    //        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("time"), GUIContent.none);

    //        // Set indent back to what it was
    //        EditorGUI.indentLevel = indent;

    //        EditorGUI.EndProperty();
    //    }
    //}
}
