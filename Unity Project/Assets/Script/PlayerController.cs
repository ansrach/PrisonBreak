// GENERATED AUTOMATICALLY FROM 'Assets/Script/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""PlayerAction"",
            ""id"": ""dfe22691-8b2e-4682-8ad9-af6ab38da57d"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""4873eaf6-6630-4eab-9deb-42005b5a4c7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Junp"",
                    ""type"": ""Button"",
                    ""id"": ""aa451640-f3f4-4952-a53c-d7afc1d19f77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ebe9ab6-0bd6-4bb0-9c8d-794bf2086d84"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f58aadd-e337-4072-9283-af832c17b924"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1d47208-c7f4-4957-9a02-d9b5d8e4cb0f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Junp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fc5a76a-5d87-4df0-a98f-38c4d147133e"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Junp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerAction
        m_PlayerAction = asset.FindActionMap("PlayerAction", throwIfNotFound: true);
        m_PlayerAction_Run = m_PlayerAction.FindAction("Run", throwIfNotFound: true);
        m_PlayerAction_Junp = m_PlayerAction.FindAction("Junp", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerAction
    private readonly InputActionMap m_PlayerAction;
    private IPlayerActionActions m_PlayerActionActionsCallbackInterface;
    private readonly InputAction m_PlayerAction_Run;
    private readonly InputAction m_PlayerAction_Junp;
    public struct PlayerActionActions
    {
        private @PlayerController m_Wrapper;
        public PlayerActionActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_PlayerAction_Run;
        public InputAction @Junp => m_Wrapper.m_PlayerAction_Junp;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionActions instance)
        {
            if (m_Wrapper.m_PlayerActionActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRun;
                @Junp.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnJunp;
                @Junp.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnJunp;
                @Junp.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnJunp;
            }
            m_Wrapper.m_PlayerActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Junp.started += instance.OnJunp;
                @Junp.performed += instance.OnJunp;
                @Junp.canceled += instance.OnJunp;
            }
        }
    }
    public PlayerActionActions @PlayerAction => new PlayerActionActions(this);
    public interface IPlayerActionActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnJunp(InputAction.CallbackContext context);
    }
}
