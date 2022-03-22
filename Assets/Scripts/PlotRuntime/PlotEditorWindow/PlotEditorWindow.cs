using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;
using GameEngine;
using TMPro;

internal static class PlotEditorWindowDef
{
    public static string PlotEditorDialogCardPath = "Assets/Prefab/DIALOG_NODE.prefab";
    public static string PlotEditorDialogImageSelectorPath = "Assets/Prefab/_IMG_SELECTOR.prefab";
    public static string PlotEditorDialogImageCardPath = "Assets/Prefab/_IMG_CARD.prefab";
}

public class PlotEditorWindowDelegates
{
    public delegate PlotEditorCard CreateCardDelegate(Vector3 position);
}

public class PlotEditorPrefabData
{
    public static PlotEditorPrefabData Ins = new PlotEditorPrefabData();

    public GameObject DialogCardPrefab;
    public GameObject DialogImageSelectorPrefab;
    public GameObject DialogImageCardPrefab;

    public void LoadPrefab()
    {
        DialogCardPrefab = AssetDatabase.LoadAssetAtPath(PlotEditorWindowDef.PlotEditorDialogCardPath, typeof(GameObject)) as GameObject;
        DialogImageSelectorPrefab = AssetDatabase.LoadAssetAtPath(PlotEditorWindowDef.PlotEditorDialogImageSelectorPath, typeof(GameObject)) as GameObject;
        DialogImageCardPrefab = AssetDatabase.LoadAssetAtPath(PlotEditorWindowDef.PlotEditorDialogImageCardPath, typeof(GameObject)) as GameObject;
    }
}


public class PlotEditorWindow : UIPanel
{
    public static PlotEditorWindow Ins;

    public string CreatePlotBtn = "_TOP/_TOP_BAR/BTN_CREATE_PLOT";
    public string OpenPlotBtn = "_TOP/_TOP_BAR/BTN_LOAD_PLOT";
    public string SavePlotBtn = "_TOP/_TOP_BAR/BTN_SAVE_PLOT";
    public string PreviewPlotBtn = "_TOP/_TOP_BAR/BTN_PREVIEW_PLOT";
    public string PlotRect = "_MIDDLE/_MASK/CONTENT";
    public string PlotIdInput = "_BOTTOM/_BOTTOM_BAR/_PLOT_ID";

    private Button _createPlotBtn;
    private Button _openPlotBtn;
    private Button _savePlotBtn;
    private Button _previewPlotBtn;
    private GameObject _plotRectView;
    private TMP_InputField _plotIdInput;

    private List<PlotEditorCard> _allPlotCards = new List<PlotEditorCard>();


    private void Start()
    {
        Ins = this;
        PlotEditorPrefabData.Ins.LoadPrefab();
    }

    float _mZoom = 1.0f;
    private void UpdateZoom()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        if (zoom == 0)
            return;

        if ((_mZoom <= 0.1f && zoom < 0) || (_mZoom >= 2.0f && zoom > 0))
            return;

        _mZoom += zoom;
        _plotRectView.transform.localScale = new Vector3(_mZoom, _mZoom, 1);
    }

    private bool _beginDrag = false;
    private Vector2 _lastMousePos = Vector2.zero;
    private void UpdateDrag()
    {
        if (_beginDrag)
        {
            _plotRectView.transform.localPosition += new Vector3(Input.mousePosition.x - _lastMousePos.x, Input.mousePosition.y - _lastMousePos.y, 0);
            _lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _beginDrag = true;
            _lastMousePos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(1))
        {
            _beginDrag = false;
            _lastMousePos = Vector2.zero;
        }
    }

    protected override void OnUpdate(float deltaTime)
    {
        UpdateZoom();
        UpdateDrag();

        foreach(PlotEditorCard card in _allPlotCards)
        {
            card.CardUpdate(Time.deltaTime);
        }
    }

    private int _maxCardId = -1;
    private void CreateNewCard(Vector3 position,int prevCardId,bool isStart)
    {
        UIManager.Ins.AddControl<PlotDialogEditorCard>(this, "Prefab/DIALOG_NODE", _plotRectView, (UIEntity ui) =>
        {
            PlotDialogEditorCard card = ui as PlotDialogEditorCard;
            if (card != null)
            {
                _maxCardId++;
                card.InitCard(_maxCardId, prevCardId, isStart);
                _allPlotCards.Add(card);
                card.SetPosition(position);
            }
        });
    }

    public void ShowImgSelector(bool show)
    {
    }

    private void CreatePlot()
    {
        CreateNewCard(Vector3.zero, -1, true);
    }

    private void OpenPlot()
    {
        Log.Logic(LogLevel.Normal, "open a plot");
        

    }

    private void SavePlot()
    {

    }

    private void PreviewPlot()
    {

    }

    public override string GetPanelLayerPath()
    {
        return UIPathDef.UI_LAYER_NORMAL_STATIC;
    }

    protected override void BindUINodes()
    {
        BindButtonNode(ref _createPlotBtn, CreatePlotBtn, CreatePlot);
        BindButtonNode(ref _openPlotBtn, OpenPlotBtn, OpenPlot);
        BindButtonNode(ref _savePlotBtn, SavePlotBtn, SavePlot);
        BindButtonNode(ref _previewPlotBtn, PreviewPlotBtn,PreviewPlot);
        BindNode(ref _plotRectView, PlotRect);
        BindInputFieldNode(ref _plotIdInput, PlotIdInput);
    }

    protected override void OnOpen()
    {
        Log.Logic("plot edit window open");
    }

    protected override void OnClose()
    {
        Log.Logic("plot edit window close");
    }

    public override void CustomClear()
    {

    }
}
