// GENERATED AUTOMATICALLY FROM 'Assets/Plugin/JUI/Controller/ActorControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace JackUtil
{
    public class @ActorControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ActorControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActorControls"",
    ""maps"": [
        {
            ""name"": ""Normal"",
            ""id"": ""cfdfcf40-a949-4651-b8a3-7c5005ef0220"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8a083fce-0129-4fb5-a14c-d0d8205a9b30"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Act1"",
                    ""type"": ""Button"",
                    ""id"": ""fbd84f61-a8cf-44df-a05e-c28911c2a3ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Act2"",
                    ""type"": ""Button"",
                    ""id"": ""a286a3e5-54a1-4fb0-b19a-e0fb74171f2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Act3"",
                    ""type"": ""Button"",
                    ""id"": ""7e4c32d0-ee04-410b-ac29-c99d0abd31d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Act4"",
                    ""type"": ""Button"",
                    ""id"": ""4f66e556-bf09-4b18-93b6-362672d81fff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d5c2db60-a1d3-4169-adb2-f5d1403a1e50"",
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
                    ""id"": ""7a8842f8-6b46-4561-bd7e-3de12313945c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bd94bd7d-0608-4698-99bc-1509dc2bff33"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1c77f949-99c8-4242-b773-997ab81a3b08"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c24dea01-7585-404b-8852-15181d703a66"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""67565123-3e9c-478a-b4ae-506c9e3bf5b5"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Act1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bc1811a-b854-4000-b5e9-383188f72846"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Act2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee67dcdc-ff20-4635-a435-9c4e6ce84d87"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Act3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b78c394d-2a3c-4bb4-add7-b61f026cbc96"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ActorKeyboard"",
                    ""action"": ""Act4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ActorKeyboard"",
            ""bindingGroup"": ""ActorKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Normal
            m_Normal = asset.FindActionMap("Normal", throwIfNotFound: true);
            m_Normal_Movement = m_Normal.FindAction("Movement", throwIfNotFound: true);
            m_Normal_Act1 = m_Normal.FindAction("Act1", throwIfNotFound: true);
            m_Normal_Act2 = m_Normal.FindAction("Act2", throwIfNotFound: true);
            m_Normal_Act3 = m_Normal.FindAction("Act3", throwIfNotFound: true);
            m_Normal_Act4 = m_Normal.FindAction("Act4", throwIfNotFound: true);
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

        // Normal
        private readonly InputActionMap m_Normal;
        private INormalActions m_NormalActionsCallbackInterface;
        private readonly InputAction m_Normal_Movement;
        private readonly InputAction m_Normal_Act1;
        private readonly InputAction m_Normal_Act2;
        private readonly InputAction m_Normal_Act3;
        private readonly InputAction m_Normal_Act4;
        public struct NormalActions
        {
            private @ActorControls m_Wrapper;
            public NormalActions(@ActorControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Normal_Movement;
            public InputAction @Act1 => m_Wrapper.m_Normal_Act1;
            public InputAction @Act2 => m_Wrapper.m_Normal_Act2;
            public InputAction @Act3 => m_Wrapper.m_Normal_Act3;
            public InputAction @Act4 => m_Wrapper.m_Normal_Act4;
            public InputActionMap Get() { return m_Wrapper.m_Normal; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(NormalActions set) { return set.Get(); }
            public void SetCallbacks(INormalActions instance)
            {
                if (m_Wrapper.m_NormalActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnMovement;
                    @Act1.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct1;
                    @Act1.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct1;
                    @Act1.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct1;
                    @Act2.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct2;
                    @Act2.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct2;
                    @Act2.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct2;
                    @Act3.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct3;
                    @Act3.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct3;
                    @Act3.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct3;
                    @Act4.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct4;
                    @Act4.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct4;
                    @Act4.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnAct4;
                }
                m_Wrapper.m_NormalActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Act1.started += instance.OnAct1;
                    @Act1.performed += instance.OnAct1;
                    @Act1.canceled += instance.OnAct1;
                    @Act2.started += instance.OnAct2;
                    @Act2.performed += instance.OnAct2;
                    @Act2.canceled += instance.OnAct2;
                    @Act3.started += instance.OnAct3;
                    @Act3.performed += instance.OnAct3;
                    @Act3.canceled += instance.OnAct3;
                    @Act4.started += instance.OnAct4;
                    @Act4.performed += instance.OnAct4;
                    @Act4.canceled += instance.OnAct4;
                }
            }
        }
        public NormalActions @Normal => new NormalActions(this);
        private int m_ActorKeyboardSchemeIndex = -1;
        public InputControlScheme ActorKeyboardScheme
        {
            get
            {
                if (m_ActorKeyboardSchemeIndex == -1) m_ActorKeyboardSchemeIndex = asset.FindControlSchemeIndex("ActorKeyboard");
                return asset.controlSchemes[m_ActorKeyboardSchemeIndex];
            }
        }
        public interface INormalActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnAct1(InputAction.CallbackContext context);
            void OnAct2(InputAction.CallbackContext context);
            void OnAct3(InputAction.CallbackContext context);
            void OnAct4(InputAction.CallbackContext context);
        }
    }
}
