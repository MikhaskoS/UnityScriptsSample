using UnityEngine;
using System.Collections;

public class UpdateViaGodClass : MonoBehaviour, IUpdateableObject {

	[SerializeField] AIControllerComponent _ai = null;

	void Start() {
		GameLogic.Instance.RegisterUpdateableObject(this);
		Initialize();
	}
	
	void OnDestroy() {
		if (GameLogic.IsAlive) {
			GameLogic.Instance.DeregisterUpdateableObject(this);
		}
	}
	
	protected virtual void Initialize() { 
		// derived classes should override this method for initialization code
		// to avoid replacing the Start() function accidentally
	}

	public virtual void OnUpdate(float dt) {
		_ai.ProcessAI();
	}

}
