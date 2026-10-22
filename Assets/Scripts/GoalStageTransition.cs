
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalStageTransition : MonoBehaviour
{
    public Sprite firstSprite;
    public Sprite secondSprite;
    public Sprite thirdSprite;
    public Sprite fourthSprite;
    public Sprite fifthSprite;
    public SpriteRenderer fifthSpriteRenderer;

    public float waitTime = 2f;
    public string nextStageName = "Stage3";

    private SpriteRenderer spriteRenderer;
    private bool isTransitioning = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Goal에 SpriteRenderer가 없습니다.");
            return;
        }

        if (firstSprite != null)
        {
            spriteRenderer.sprite = firstSprite;
        }
    }

    public void ChangeAndNextStage()
    {
        if (isTransitioning) return;

        if (spriteRenderer == null ||
            firstSprite == null ||
            secondSprite == null ||
            thirdSprite == null ||
            fourthSprite == null ||
            fifthSprite == null ||
            fifthSpriteRenderer == null)
        {
            Debug.LogError("Goal의 이미지 4장을 모두 연결해 주세요.");
            return;
        }


        StartCoroutine(ChangeSpritesAndLoadStage());
    }

    IEnumerator ChangeSpritesAndLoadStage()
    {
        isTransitioning = true;

        spriteRenderer.sprite = firstSprite;
        yield return new WaitForSeconds(waitTime);

        spriteRenderer.sprite = secondSprite;
        yield return new WaitForSeconds(waitTime);

        spriteRenderer.sprite = thirdSprite;
        yield return new WaitForSeconds(waitTime);

        spriteRenderer.sprite = fourthSprite;
        yield return new WaitForSeconds(waitTime);

        // 이미지 4는 그대로 두고, 다른 위치에 이미지 5 표시
        fifthSpriteRenderer.sprite = fifthSprite;
        fifthSpriteRenderer.gameObject.SetActive(true);

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(nextStageName);
    }
}
