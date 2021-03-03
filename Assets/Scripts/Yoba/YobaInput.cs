// GENERATED AUTOMATICALLY FROM 'Assets/YobaInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @YobaInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @YobaInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""YobaInput"",
    ""maps"": [
        {
            ""name"": ""Yoba"",
            ""id"": ""b1198cb2-2303-4d24-86c9-99e9ff188cf3"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""843e91e2-d62f-4bf3-bfe3-0ed8a29376f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a616a97-23f5-4e83-bdd7-7f3c91513382"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""YobaInput"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""YobaInput"",
            ""bindingGroup"": ""YobaInput"",
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
        // Yoba
        m_Yoba = asset.FindActionMap("Yoba", throwIfNotFound: true);
        m_Yoba_Jump = m_Yoba.FindAction("Jump", throwIfNotFound: true);
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

    // Yoba
    private readonly InputActionMap m_Yoba;
    private IYobaActions m_YobaActionsCallbackInterface;
    private readonly InputAction m_Yoba_Jump;
    public struct YobaActions
    {
        private @YobaInput m_Wrapper;
        public YobaActions(@YobaInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Yoba_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Yoba; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(YobaActions set) { return set.Get(); }
        public void SetCallbacks(IYobaActions instance)
        {
            if (m_Wrapper.m_YobaActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_YobaActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_YobaActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_YobaActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_YobaActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public YobaActions @Yoba => new YobaActions(this);
    private int m_YobaInputSchemeIndex = -1;
    public InputControlScheme YobaInputScheme
    {
        get
        {
            if (m_YobaInputSchemeIndex == -1) m_YobaInputSchemeIndex = asset.FindControlSchemeIndex("YobaInput");
            return asset.controlSchemes[m_YobaInputSchemeIndex];
        }
    }
    public interface IYobaActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
}
