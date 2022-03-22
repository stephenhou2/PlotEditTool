﻿using UnityEngine;

namespace GameEngine
{
    public class CameraManager : Singleton<CameraManager>
    {
        public Camera MainCam;
        public CameraManager()
        {
            MainCam = Camera.main;
        }

        public void ChangeMainCam(Camera cam)
        {
            if(cam == null)
            {
                Log.Error(ErrorLevel.Critical, "ChangeMainCam Failed, target cam is null!");
                return;
            }

            MainCam = cam;
        }

        public void Update(float deltaTime)
        {

        }

        public void LateUpdate(float deltaTime)
        {

        }

        public void DisposeCameraManager()
        {

        }
    }
}
