using UnityEngine;
using DragonBones;

public class AnimatorArmatureSetter : MonoBehaviour
{
    [SerializeField] private string _anim1;
    [SerializeField] private string _anim2;

    private UnityArmatureComponent player;

    void Start()
    {
        player = GetComponent<UnityArmatureComponent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            player.animation.FadeIn(_anim1, 0.25f, -1);

            //player.animation.Play((_anim1));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            player.animation.FadeIn(_anim2, 0.25f, -1);

            //player.animation.Play((_anim2));
        }
    }
}
