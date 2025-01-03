using KinematicCharacterController.Examples;
using System;
using UnityEngine;
using UnityEngine.UI;



public class MyPlayer : MonoBehaviour
{
    public GameObject oldKeyObj;
    public GameObject flaskObj;

    public ExampleCharacterCamera OrbitCamera;
    public Transform CameraFollowPoint;
    public MyCharacterController Character;
    private bool hasOldKey;
    private bool unlockDeskDoor;
    private bool hasAnti;
    private bool hasDote;
    private bool hasAntiDote;
    private Camera secondaryCam;
    private GraphicRaycaster secondaryRaycaster;
    private const string MouseXInput = "Mouse X";
    private const string MouseYInput = "Mouse Y";
    private const string MouseScrollInput = "Mouse ScrollWheel";
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Tell camera to follow transform
        OrbitCamera.SetFollowTransform(CameraFollowPoint);

        // Ignore the character's collider(s) for camera obstruction checks
        OrbitCamera.IgnoredColliders.Clear();
        OrbitCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
    }

    private void Update()
    {
        if (secondaryCam != null) // we zoomed on another camera
        {
            if (Input.GetMouseButtonDown(1))
            {
                ResetCamera();
            }
        }
        else // we are in first person on player
        {
            if (!PauseMenu.IsPaused && Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Character.TryToInteract();
            }

            HandleCharacterInput();
        }

        
    }

    private void ResetCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
        secondaryCam.gameObject.SetActive(false);
        secondaryCam = null;

        secondaryRaycaster.enabled = false;
        secondaryRaycaster = null;

        OrbitCamera.gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        HandleCameraInput();
    }

    private void HandleCameraInput()
    {
        // Create the look input vector for the camera
        float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
        float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
        Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

        // Prevent moving the camera while the cursor isn't locked
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            lookInputVector = Vector3.zero;
        }

        // Input for zooming the camera (disabled in WebGL because it can cause problems)
        float scrollInput = -Input.GetAxis(MouseScrollInput);
#if UNITY_WEBGL
        scrollInput = 0f;
#endif

        // Apply inputs to the camera
        OrbitCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);

        // Handle toggling zoom level
        if (Input.GetMouseButtonDown(1))
        {
            OrbitCamera.TargetDistance = (OrbitCamera.TargetDistance == 0f) ? OrbitCamera.DefaultDistance : 0f;
        }
    }

    private void HandleCharacterInput()
    {
        PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

        // Build the CharacterInputs struct
        characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
        characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
        characterInputs.CameraRotation = OrbitCamera.Transform.rotation;

        // Apply inputs to character
        Character.SetInputs(ref characterInputs);
    }

    internal void CollectOldKey()
    {
        hasOldKey = true;
        oldKeyObj.SetActive(true);
    }

    internal void UnluckDeskDoor()
    {
        unlockDeskDoor = true;
    }

    internal void CollectAnti()
    {
        hasAnti = true;
    }
    internal void CollectDote()
    {
        hasDote = true;
    }
    internal void CollectAntiDote()
    {
        hasAntiDote = true;
        flaskObj.SetActive(true);
    }

    internal void DropAnti()
    {
        hasAnti = false;
    }

    internal void DropDote()
    {
        hasDote = false;
    }

    internal void SetSecondaryCamera(Camera monitorCamera, GraphicRaycaster raycaster)
    {
        secondaryCam = monitorCamera;
        secondaryRaycaster = raycaster;

        Cursor.lockState = CursorLockMode.Confined;
        OrbitCamera.gameObject.SetActive(false);
        secondaryCam.gameObject.SetActive(true);
        raycaster.enabled = true;
    }

    public bool HasOldKey => hasOldKey;

    public bool UnlockedDeskDoor => unlockDeskDoor;

    public bool HasAnti => hasAnti;
    public bool HasDote => hasDote;
    public bool HasAntiDote => hasAntiDote;
}
