/* Created by and for usage of FF Studios (2021). */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockInfoUI : MonoBehaviour
{
	public EventListenerDelegateResponse event_listener_blockInfo;

	public Image image;
	public Button button;
	public TextMeshProUGUI textRenderer;

	private void OnDisable()
    {
		event_listener_blockInfo.OnDisable();
	}

	private void Start()
    {
		event_listener_blockInfo.OnEnable();
		event_listener_blockInfo.response = OnBlockInfoResponse;
	}

    public void CloseBlockInfoUI()
    {
		image.enabled        = false;
		textRenderer.enabled = false;
		button.gameObject.SetActive( false );
    }

    void OnBlockInfoResponse()
    {
		var gameEvent = event_listener_blockInfo.gameEvent as BlockInfoGameEvent;
		textRenderer.text = $"Block Info:\nGrade Level:{gameEvent.block_info_gradeLevel}: {gameEvent.block_info_domain} \nCluster:{gameEvent.block_info_cluster} \nDescription:{gameEvent.block_info_standartDescription}";

		image.enabled = true;
		textRenderer.enabled = true;
		button.gameObject.SetActive( true );
	}
}