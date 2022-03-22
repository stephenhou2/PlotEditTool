using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData
{
    /// <summary>
    /// ��ǰ�Ի��ڵ�ı���id
    /// </summary>
    public string Title;
    /// <summary>
    /// ��ǰ�Ի��ڵ������
    /// </summary>
    public string Content;
    /// <summary>
    /// ��ǰ�Ի��ڵ����ͼ
    /// </summary>
    public string Img;
    /// <summary>
    /// ��ǰ�Ի��ڵ������
    /// </summary>
    public string Sound;
    /// <summary>
    ///  ��ǰ�Ի��ڵ����Ƶ
    /// </summary>
    public string Video;
    /// <summary>
    /// ��ǰ�Ի��ڵ��ѡ������
    /// </summary>
    public DialogOptionData[] Options;
    /// <summary>
    /// ��ǰ�Ի��ڵ�ĺ����Ի�
    /// </summary>
    public DialogData FollowedDialog;
}
