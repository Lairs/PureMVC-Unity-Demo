using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PureMVC.Interfaces;
using System;

public class UnityFacade : PureMVC.Patterns.Facade {

	const string STARTUP = "UnityFacade.StartUp";

	//Lairs:set bool avoid call Startup again.
	static bool startupRun = false;

	static UnityFacade()
	{
		m_instance = new UnityFacade();
		//Lairs:run Startup on create instance, current works.
		(m_instance as UnityFacade).StartUp ();
    }
	 
	// Override Singleton Factory method 
	public static UnityFacade GetInstance() {
		return m_instance as UnityFacade;
	}

	protected override void InitializeController() {
		Debug.Log("Facade InitializeController");
		base.InitializeController();
		RegisterCommand( STARTUP, typeof(StartUpCommand)  );
	}
		
	public void StartUp()
	{
		if(startupRun)
		{
			return;
		}

		startupRun = true;
		SendNotification( STARTUP );
		//Lairs:unregist command
		RemoveCommand(STARTUP);

	}

	//Handle IMediatorPlug connection
	public void ConnectMediator( IMediatorPlug item )
	{
		//manual find type by class
		Type mediatorType = Type.GetType( item.GetClassRef() );
		if( null != mediatorType){
			//build new mediator by manual call create
			IMediator mediatorPlug = (IMediator)Activator.CreateInstance( mediatorType, item.GetName(), item.GetView() ) ;
			RegisterMediator( mediatorPlug );
		}
	}

	public void DisconnectMediator( string mediatorName )
	{
		RemoveMediator( mediatorName );
	}
}
