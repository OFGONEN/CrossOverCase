using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StackInfoLoader stack_info_loader;
    public StackCreator stack_creator;

    private void Awake()
    {
		stack_info_loader.LoadStackInformations();
		stack_creator.CreateStacks();
	}
}