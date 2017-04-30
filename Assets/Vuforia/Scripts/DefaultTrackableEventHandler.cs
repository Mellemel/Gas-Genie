/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using System.Net;
using System.IO;
using CI.HttpClient;
using System;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

//			Application.CaptureScreenshot ("/tmp/gas_genie_capture.png");
//			string url = "https://api.clarifai.com/v2/models/aaa03c23b3724a16a56b629203edc62c/outputs";
//			WWWForm wwwform = new WWWForm();
//			wwwform.AddField(
//			WWW clarifai_url = new WWW(url);
//			HttpWebRequest a = new HttpWebRequest();
//			WebRequest request = WebRequest.Create(url);
//			request.Credentials = CredentialCache.DefaultCredentials; // TODO: Are these the right credentials?
//			((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
//			request.Method = "POST";
//			string postData = "This is a test that posts this string to a Web server.";  
//			byte[] byteArray = Encoding.UTF8.GetBytes (postData);
//			request.ContentLength = byteArray.Length; //TODO: Make ByteArray
//			request.ContentType = "application/x-www-form-urlencoded"; 
//			Stream dataStream = request.GetRequestStream ();
//			dataStream.Write (byteArray, 0, byteArray.Length);
//			dataStream.Close ();
//			WebResponse response = request.GetResponse();
//			Debug.Log (((HttpWebResponse)response).StatusDescription);
//			Stream data = response.GetResponseStream;
//			response.Close();


			// HttpClient
//			HttpClient httpClient = new HttpClient();
//			string mydata =
//				"{\"inputs\":[{\"data\":{\"image\":{\"base64\":";
//			
//			// TODO: Convert image data from bytes into string
//			//Create a texture to pass to encoding
//			Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
//
//			//Put buffer into texture
//			texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0); //Unity complains about this line's call being made "while not inside drawing frame", but it works just fine.*
//			byte[] mybytes;
//			mybytes = texture.EncodeToJPG();
//			File.WriteAllBytes("/Users/nbelakovski/temp/pic.jpg", mybytes);
//			string result = Convert.ToBase64String(mybytes);
//			Debug.Log (result.Length);
//			Debug.Log (result);
//			mydata += result;
//
//			mydata += "}}}]}";
//			Debug.Log (mydata);
//
//			Debug.Log(mydata.Substring(mydata.Length - 10, 10));
//			string str;
//			httpClient.Headers.Remove (HttpRequestHeader.ContentType);
//			httpClient.Headers.Add(new System.Collections.Generic.KeyValuePair<HttpRequestHeader, string>(HttpRequestHeader.ContentType, "application/json"));
//			httpClient.Headers.TryGetValue(HttpRequestHeader.ContentType, out str);
//			Debug.Log (str);//.Add(HttpRequestHeader.ContentType, "application/json");
//			httpClient.CustomHeaders.Add(new System.Collections.Generic.KeyValuePair<string, string>("Authorization", "Bearer 8wyLGTKqv9YUJWvDNlyxSOWMJ9xixj"));
//
//			string urlstring = "{\"inputs\":[{\"data\":{\"image\":{\"url\":http://www.tbotech.com/images/thumbnails/465/465/detailed/2/coke-can-secret-safe.jpg}}}]}";
//			httpClient.Post(new System.Uri(url), new StringContent(urlstring), (r) => 
//				{
//					// Raised when the download completes
//					Debug.Log("Download complete");
//					Debug.Log(r.ContentLength);
//					Debug.Log(r.Data);
//					Debug.Log(r.StatusCode);
//					Debug.Log(r.OriginalResponse);
//					Debug.Log(r.OriginalRequest.Headers);
//
////					Debug.Log(r.OriginalRequest.AuthenticationLevel);
////					Debug.Log(r.OriginalRequest.MediaType);
//				}, (u) =>
//				{
//					// Raised periodically when uploading
//				});


            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

			transform.Find ("Canvas").gameObject.SetActive (true);

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

			transform.Find ("Canvas").gameObject.SetActive (false);

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
