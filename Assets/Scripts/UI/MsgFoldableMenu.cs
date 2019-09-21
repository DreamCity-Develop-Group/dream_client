/***
  * Title:     �ʼ��۵�����
  *
  * Created:	zzg
  *
  * CreatTime:  2019/09/21
  *
  * Description:
  *
  * Version:    0.1
  *
  *
***/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  �ʼ��۵�����
/// </summary>
public class MsgFoldableMenu : MonoBehaviour
{
    private RectTransform content;//�������parent
    private TextAsset textAsset;//���в˵���Ϣ
    private RectTransform parentRect;//���˵���prefab
    private RectTransform[] parentArr;//���и��˵�������
    private RectTransform childRect;//�Ӳ˵���prefab
    private Vector3 parentOffset;//�������˵��ĸ߶�
    private Vector3 childOffset;//�������˵��ĸ߶�
    private int[] cntArr;//���и��˵�ӵ�е��Ӳ˵�����
    private int MaliCount = 0;  //�ʼ���
    private string EmailContent = null; //�ʼ���Ϣ



    private void Start()
    {      
        Init();
    }

    void Init()
    {
        MaliCount = 2;
        content = transform.Find("Viewport/Content").GetComponent<RectTransform>();
        textAsset = Resources.Load<TextAsset>("MsgInfo");

        parentRect = Resources.Load<RectTransform>("MailBox");
        parentOffset = new Vector3(0, parentRect.rect.height);

        childRect = Resources.Load<RectTransform>("MailInfo");
        childOffset = new Vector3(0, childRect.rect.height);

        var info = textAsset.text.Split(',');//��ȡ�Ӳ˵�������Ϣ
        cntArr = new int[info.Length];
        parentArr = new RectTransform[MaliCount];
        //��ʼ��content�߶�
        content.sizeDelta = new Vector2(content.rect.width, parentArr.Length * parentRect.rect.height);

        if(MaliCount>0)
        {
            for (int i = 0; i < MaliCount; i++)
            {
                parentArr[i] = Instantiate(parentRect, content.transform);
                //��д�ʼ��ı��⣬����ʱ�䣬�ʼ�����
                switch (i)
                {
                    case 0:
                        parentArr[i].transform.Find("MailTitle").GetComponent<Text>().text = "�ʼ�����";
                        parentArr[i].transform.Find("Time").GetComponent<Text>().text = "����ʱ��";
                        break;
                    case 1:
                        parentArr[i].transform.Find("MailTitle").GetComponent<Text>().text = "�ʼ�����";
                        parentArr[i].transform.Find("Time").GetComponent<Text>().text = "����ʱ��";
                        break;
                    case 2:
                        parentArr[i].transform.Find("MailTitle").GetComponent<Text>().text = "�ʼ�����";
                        parentArr[i].transform.Find("Time").GetComponent<Text>().text = "����ʱ��";
                        break;
                    case 3:
                        parentArr[i].transform.Find("MailTitle").GetComponent<Text>().text = "�ʼ�����";
                        parentArr[i].transform.Find("Time").GetComponent<Text>().text = "����ʱ��";
                        break;
                }
                parentArr[i].localPosition -= i * parentOffset;
                cntArr[i] = int.Parse(info[i]);
                parentArr[i].GetComponent<ParentMenu>().Init(childRect, cntArr[i], EmailContent);
                int j = i;
                parentArr[i].GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(j); });
            }
        }
        
           
    }

    void OnButtonClick(int i)
    {
        if (!parentArr[i].GetComponent<ParentMenu>().isCanClick) return;
        parentArr[i].GetComponent<ParentMenu>().isCanClick = false;
        if (!parentArr[i].GetComponent<ParentMenu>().isOpening)
            StartCoroutine(MenuDown(i));
        else
            StartCoroutine(MenuUp(i));
    }

    IEnumerator MenuDown(int index)
    {
        for (int i = 0; i < cntArr[index]; i++)
        {
            //����content�߶�
            content.sizeDelta = new Vector2(content.rect.width,
                content.rect.height + childOffset.y);
            for (int j = index + 1; j < parentArr.Length; j++)
            {
                parentArr[j].localPosition -= childOffset;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator MenuUp(int index)
    {
        for (int i = 0; i < cntArr[index]; i++)
        {
            //����content�߶�
            content.sizeDelta = new Vector2(content.rect.width,
                content.rect.height - childOffset.y);
            for (int j = index + 1; j < parentArr.Length; j++)
            {
                parentArr[j].localPosition += childOffset;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
