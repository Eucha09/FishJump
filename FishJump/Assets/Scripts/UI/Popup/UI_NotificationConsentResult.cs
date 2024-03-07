using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_NotificationConsentResult : UI_Popup
{
    enum Buttons
    {
        CloseButton,
    }

    enum Texts
    {
        ResultText,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnCloseButton);

        string nowDate = DateTime.Now.ToString("yyyy�� MM�� dd��");
        string text = $"������ : �����ΰ�����\n�Ͻ� : {nowDate}\n���� : ���ŵ��� ó�� �Ϸ�";
        GetText((int)Texts.ResultText).text = text;
    }

    public void OnCloseButton(PointerEventData data)
    {

        Managers.UI.ClosePopupUI();
    }
}
