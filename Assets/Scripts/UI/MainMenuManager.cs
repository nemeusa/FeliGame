using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] GameObject _tableroBig;

    [SerializeField] Animator _aniMenu;
    [SerializeField] Animator _aniFeliMenu;
    [SerializeField] Transform _feliPost;

    [SerializeField] Transform _feliInitialPost;
    [SerializeField] Transform _feliFinalPost;

    bool move;


    void Start()
    {
        _tableroBig.SetActive(false);

    }
    private void Update()
    {
        if (move)
        {
            if (_feliPost.position.x <= _feliFinalPost.position.x) _feliPost.position = new Vector2(_feliPost.position.x + 400 * Time.deltaTime, _feliPost.position.y);
            else
            {
                _aniFeliMenu.SetBool("Move", false);
                _feliPost.localScale = new Vector2(-1, _feliPost.localScale.y);
            }
        }
        else
        {
            if (_feliPost.position.x >= _feliInitialPost.position.x) _feliPost.position = new Vector2(_feliPost.position.x - 400 * Time.deltaTime, _feliPost.position.y);
            else
            {
                _aniFeliMenu.SetBool("Move", false);
                _feliPost.localScale = new Vector2(1, _feliPost.localScale.y);
            }
        }
    }

    public void TableroActive(bool onTurn)
    {
        _tableroBig.SetActive(onTurn);
        _aniFeliMenu.SetBool("Move", true);
        move = onTurn;
    }

    public void MenuCatColor(bool ke)
    {
        _aniMenu.SetBool("LevelMenu", ke);
    }

}
