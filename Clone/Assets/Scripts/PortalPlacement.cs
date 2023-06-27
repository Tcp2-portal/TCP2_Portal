using UnityEngine;

[RequireComponent(typeof(CameraMove))]
    public class PortalPlacement : MonoBehaviour
    {
        [SerializeField]
        private PortalPair portals;
        private  Vector3 position;
        private Vector3 forward;
        public Transform t;

        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        private Crosshair crosshair;

        // private CameraMove cameraMove;
        private RaycastHit hit;
        // private void Awake()
        // {
        //     cameraMove = GetComponent<CameraMove>();
        // }

        private void Update()
        {
            // if(Input.GetButtonDown("Fire1"))
            // {
            //     FirePortal(0, transform.position, transform.forward, 250.0f);
            // }
            // else 
            // if (Input.GetButtonDown("Fire2"))
            // {
            //     Physics.Raycast(t.position, t.forward, out hit, 250.0f, layerMask);
            //     Invoke("Fire", 0.5f);
            // }
        }
        public void OpenPoratal(int portalID, Vector3 pos, Vector3 dir, float distance)
        {
            Physics.Raycast(pos, dir, out hit, distance, layerMask);
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            if (hit.collider != null)
            {
                // If we shoot a portal, recursively fire through the portal.
                if (hit.collider.CompareTag("Ray")){
                    return;
                }
                if (hit.collider.tag == "Portal")
                {
                    var inPortal = hit.collider.GetComponent<Portal>();

                    if (inPortal == null)
                    {
                        return;
                    }

                    var outPortal = inPortal.OtherPortal;

                    // Update position of raycast origin with small offset.
                    Vector3 relativePos = inPortal.transform.InverseTransformPoint(hit.point + dir);
                    relativePos = Quaternion.Euler(0.0f, 180.0f, 0.0f) * relativePos;
                    pos = outPortal.transform.TransformPoint(relativePos);

                    // Update direction of raycast.
                    Vector3 relativeDir = inPortal.transform.InverseTransformDirection(dir);
                    relativeDir = Quaternion.Euler(0.0f, 180.0f, 0.0f) * relativeDir;
                    dir = outPortal.transform.TransformDirection(relativeDir);

                    distance -= Vector3.Distance(pos, hit.point);

                    OpenPoratal(portalID, pos, dir, distance);

                    return;
                }

                // Orient the portal according to camera look direction and surface direction.
                //###############################poracaso funcionou melhor dessa forma###################
                //var cameraRotation = cameraMove.TargetRotation;
                var cameraRotation = transform.rotation;
                //#######################################################################################
                var portalRight = cameraRotation * Vector3.right;

                if (Mathf.Abs(portalRight.x) >= Mathf.Abs(portalRight.z))
                {
                    portalRight = (portalRight.x >= 0) ? Vector3.right : -Vector3.right;
                }
                else
                {
                    portalRight = (portalRight.z >= 0) ? Vector3.forward : -Vector3.forward;
                }

                var portalForward = -hit.normal;
                var portalUp = -Vector3.Cross(portalRight, portalForward);

                var portalRotation = Quaternion.LookRotation(portalForward, portalUp);

                // Attempt to place the portal.
                bool wasPlaced = portals.Portals[portalID].PlacePortal(hit.collider, hit.point, portalRotation);
                if (wasPlaced)
                {
                    crosshair.SetPortalPlaced(portalID, true);
                }
            }
        }
    }
