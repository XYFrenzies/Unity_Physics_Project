// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input System/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""24df5184-8ac8-46ae-b388-11744f462414"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""7ad554a1-e69a-4468-854e-3f48555ad6f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""1657ef33-34b5-454e-8369-8de140ad5ea0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Player Aim"",
                    ""type"": ""Button"",
                    ""id"": ""75eb8a40-81b3-44c5-92e2-84d7573444b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeapons"",
                    ""type"": ""Button"",
                    ""id"": ""8d8e7de6-45b1-4814-a745-9aabefae12b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveObjects"",
                    ""type"": ""Button"",
                    ""id"": ""280136a3-acf7-499a-8ea9-4240354262dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Acceleration"",
                    ""type"": ""Button"",
                    ""id"": ""1ee7f078-42a6-455c-a133-80fa4989f048"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cdedbfbf-3b30-47eb-b197-76653f9811cc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8e44a25e-e1f1-4a19-894a-e084b489d2af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""45319e23-4c16-40e3-8520-c505d8eb5c00"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8aa04d3f-416c-4162-b6b6-6acc77694410"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b6c17dce-84aa-4c36-9c3d-642bdca230f3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""00fe6e4f-984d-468a-981a-a068bd08f93c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d458c206-5932-46ed-a89b-8b0fc1f64096"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""072934f2-e2ec-451f-8a24-7ef90edfb874"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18e34f04-2eaa-49f8-9d72-718289a3faf6"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveObjects"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acd31fec-eb63-4a4c-9a83-b31e60e66eb9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_PlayerAim = m_Player.FindAction("Player Aim", throwIfNotFound: true);
        m_Player_ChangeWeapons = m_Player.FindAction("ChangeWeapons", throwIfNotFound: true);
        m_Player_MoveObjects = m_Player.FindAction("MoveObjects", throwIfNotFound: true);
        m_Player_Acceleration = m_Player.FindAction("Acceleration", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_PlayerAim;
    private readonly InputAction m_Player_ChangeWeapons;
    private readonly InputAction m_Player_MoveObjects;
    private readonly InputAction m_Player_Acceleration;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @PlayerAim => m_Wrapper.m_Player_PlayerAim;
        public InputAction @ChangeWeapons => m_Wrapper.m_Player_ChangeWeapons;
        public InputAction @MoveObjects => m_Wrapper.m_Player_MoveObjects;
        public InputAction @Acceleration => m_Wrapper.m_Player_Acceleration;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @PlayerAim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerAim;
                @PlayerAim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerAim;
                @PlayerAim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayerAim;
                @ChangeWeapons.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeWeapons;
                @ChangeWeapons.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeWeapons;
                @ChangeWeapons.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeWeapons;
                @MoveObjects.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObjects;
                @MoveObjects.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObjects;
                @MoveObjects.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObjects;
                @Acceleration.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleration;
                @Acceleration.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleration;
                @Acceleration.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleration;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @PlayerAim.started += instance.OnPlayerAim;
                @PlayerAim.performed += instance.OnPlayerAim;
                @PlayerAim.canceled += instance.OnPlayerAim;
                @ChangeWeapons.started += instance.OnChangeWeapons;
                @ChangeWeapons.performed += instance.OnChangeWeapons;
                @ChangeWeapons.canceled += instance.OnChangeWeapons;
                @MoveObjects.started += instance.OnMoveObjects;
                @MoveObjects.performed += instance.OnMoveObjects;
                @MoveObjects.canceled += instance.OnMoveObjects;
                @Acceleration.started += instance.OnAcceleration;
                @Acceleration.performed += instance.OnAcceleration;
                @Acceleration.canceled += instance.OnAcceleration;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPlayerAim(InputAction.CallbackContext context);
        void OnChangeWeapons(InputAction.CallbackContext context);
        void OnMoveObjects(InputAction.CallbackContext context);
        void OnAcceleration(InputAction.CallbackContext context);
    }
}
