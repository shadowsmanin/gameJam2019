using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newsFeed : MonoBehaviour {

    // public string news = "hello";

    private int index = 0;

    private string[] news = new string[] {
        "Minion disguises himself in bull costume and burns gfs house down with spaghetti sauce", //0
        "Minions use private planes to draw obscene radar portraits", //1
        "Minion charged with assault after using alligators as weapons", //2
        // "Minion robs ‘gamestop’ with transparent bag on head", //3
        // "Minion steals ‘neighbors’ peacock", //4
        // "Hero attacked during selfie with squirrel", //5
        // "Hero eating pancakes in middle of crosswalk", //6
        // "Minion steals BMW after being unable to buy it with food stamps", //7
        // "Sidekick arrested for posing as a doctor", //8
        // "Minion caught dancing on patrol car", //9
        // "Minion illegally rides a manatee", //10
        // "Minion caught stealing dozens of pigeons", //11
        // "Minion arrested for yelling at people from the roof of a Wendys" //12
    };

    public float scrollSpeed = 50.0f;

    Rect newsRect;

    void Start() {
        
    }

    void OnGUI() {
        // Set up the news's rect if we haven't already
        if (newsRect.width == 0) {
            Vector2 dimensions = GUI.skin.label.CalcSize(new GUIContent(news[index]));

            // Start the news past the left side of the screen
            newsRect.x = -dimensions.x;
            newsRect.width = dimensions.x;
            newsRect.height = dimensions.y;

            //print ()
        }

        newsRect.x += Time.deltaTime * scrollSpeed;

        // If the news has moved past the right side, move it back to the left
        if (newsRect.x > Screen.width) {
            newsRect.x = -newsRect.width;
            index++;
            if (index >= news.Length) {
                index = 0;
            }
        }

        GUI.Label(newsRect, news[index]);

    }

    void Update() {

    }
}
