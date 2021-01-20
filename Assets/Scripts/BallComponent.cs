using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{
    //private float fps;
    //public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float scaleSpeed = 1.0f;
    public float lenght = 3.0f;
    public float Speed = 1.0f;
    public BallInstruction Instruction = BallInstruction.Idle;
    public List<BallInstruction> Instructions = new List<BallInstruction>();
    public bool spacja = false;
    
    private Vector3 lastPosition = Vector3.zero;
    private Vector3 lastScale = Vector3.one;
    private Vector3 lastRotation = Vector3.one;
    private Vector3 vecRotation = Vector3.zero;
    private Vector3 scaleChange = Vector3.one;
    private int CurrentInstruction = 0;
    private Vector3 roznica = Vector3.zero;

    //GameState State = GameState.Start;


    /*public enum GameState
    {
        Start,
        Pause,
        Exit
    }
    */

    public enum BallInstruction
    {
        Idle = 0,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        GetBigger,
        GetSmaller,
        RotateLeft,
        RotateRight
    }

     void Start()
    {
        /*
        Debug.Log("Hello!");
        Debug.Log("State: " + State);
        int StateVal = (int)State;
        ++StateVal;
        State = (GameState)StateVal;
        Debug.Log("New State: " + State);
        Debug.Log("New State: " + (State+1));
        */

        lastPosition = transform.position;
        lastScale = transform.localScale;
   
    }

    void Update()
    {


        //################################################################################################## MODULE 1 
        /*
        Debug.Log("FPS : " + (int)(1 / Time.deltaTime));

        transform.position += Vector3.right * Time.deltaTime * speed;
        vecRotation -= Vector3.forward * rotationSpeed;
        transform.rotation = Quaternion.Euler(vecRotation);


        transform.localScale += scaleChange * Time.deltaTime * scaleSpeed;

        if (transform.localScale.x >= 3f)
            transform.localScale = new Vector3(3, 3, 3);


        Rozwiązanie alternatywne zanim doszedłem do powyższego rozwiązania 
        if (transform.localScale.x <= 3f & transform.localScale.y <= 3f & transform.localScale.z <= 3f)
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * scaleSpeed,
                                               transform.localScale.y + Time.deltaTime * scaleSpeed,
                                               transform.localScale.z + Time.deltaTime * scaleSpeed);


        Zwiększenie kulki (będę nad tym pracował, więc nie usuwam)
        if (Input.GetKey (KeyCode.A))
            transform.localScale = new Vector3(transform.localScale.x + 0.1f * scaleSpeed,
                                               transform.localScale.y + 0.1f * scaleSpeed,
                                               transform.localScale.z + 0.1f * scaleSpeed);

        Zmniejszenie kulki(będę nad tym pracował, więc nie usuwam)                   
        if (Input.GetKey(KeyCode.S))
            transform.localScale = new Vector3(transform.localScale.x - 0.1f * scaleSpeed,
                                               transform.localScale.y - 0.1f * scaleSpeed,
                                               transform.localScale.z - 0.1f * scaleSpeed);
        */

        //################################################################################################## MODULE 2 
        /*       
        switch (Instruction)
        {
            case BallInstruction.MoveUp:
                transform.position += new Vector3(0, 1, 0) * Speed * Time.deltaTime;
                break;

            case BallInstruction.MoveDown:
                transform.position -= new Vector3(0, 1, 0) * Speed * Time.deltaTime;
                break;

            case BallInstruction.MoveLeft:
                transform.position -= new Vector3(1, 0, 0) * Speed * Time.deltaTime;
                break;

            case BallInstruction.MoveRight:
                transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
                break;
            case BallInstruction.RotateLeft:
                transform.position -= Vector3.right * Time.deltaTime * speed;
                vecRotation += Vector3.forward * rotationSpeed;
                transform.rotation = Quaternion.Euler(vecRotation);
                break;
            case BallInstruction.RotateRight:
                transform.position += Vector3.right * Time.deltaTime * speed;
                vecRotation -= Vector3.forward * rotationSpeed;
                transform.rotation = Quaternion.Euler(vecRotation);
                break;

            case BallInstruction.GetBigger:
                transform.localScale += scaleChange * Time.deltaTime * scaleSpeed;

                if (transform.localScale.x >= 3f)
                    transform.localScale = new Vector3(3, 3, 3);
                break;
            case BallInstruction.GetSmaller:
                transform.localScale -= scaleChange * Time.deltaTime * scaleSpeed;

                if (transform.localScale.x <= 1f)
                    transform.localScale = new Vector3(1, 1, 1);
                break;

            default:
                Debug.Log("Idle");
                break;
        }
        */

        //################################################################################################## MODULE 2 TOPIC 2 
        if (CurrentInstruction < Instructions.Count)
        {
            float RealSpeed = Speed * Time.deltaTime;

            switch (Instructions[CurrentInstruction])
            {
                case BallInstruction.MoveUp:
                    transform.position += Vector3.up * RealSpeed;
                    break;

                case BallInstruction.MoveDown:
                    transform.position += Vector3.down * RealSpeed;
                    break;

                case BallInstruction.MoveLeft:
                    transform.position -= Vector3.right * RealSpeed;
                    break;

                case BallInstruction.MoveRight:
                    transform.position += Vector3.right * RealSpeed;
                    break;

                case BallInstruction.GetBigger:
                    transform.localScale += scaleChange * RealSpeed;
                    if (transform.localScale.x >= 3f)
                        transform.localScale = new Vector3(3, 3, 3);
                    break;

                case BallInstruction.GetSmaller:
                    transform.localScale -= scaleChange * RealSpeed;
                    if (transform.localScale.x <= 1f)
                        transform.localScale = new Vector3(1, 1, 1);
                    break;

                case BallInstruction.RotateLeft:
                    transform.eulerAngles += Vector3.forward * RealSpeed;
                    break;

                case BallInstruction.RotateRight:
                    transform.eulerAngles -= Vector3.forward * RealSpeed;
                    break;

                default:
                    Debug.Log("Idle");
                    ++CurrentInstruction;
                    break;
            }
            if (Vector3.Distance(transform.position, lastPosition) >= lenght)
            {
                lastPosition = transform.position;
                ++CurrentInstruction;
            }
            if (Vector3.Distance(transform.localScale, lastScale) >= lenght)
            {
                lastScale = transform.localScale;
                ++CurrentInstruction;
            }
            if (Mathf.Abs(transform.eulerAngles.z-lastRotation.z) >= lenght)
            {
                lastRotation = transform.eulerAngles;
                ++CurrentInstruction;
            }
        }

        //################################################################################################## MODULE 2 TOPIC 3
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown(KeyCode.W))
            transform.position += new Vector3(0, 1, 0);

        if (Input.GetKeyDown(KeyCode.DownArrow) | Input.GetKeyDown(KeyCode.S))
            transform.position -= new Vector3(0, 1, 0);

        if (Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown(KeyCode.A))
            { 
                transform.position -= new Vector3(1, 0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
            }

        if (Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
            }


        if (Input.GetKeyDown(KeyCode.Space))
            {
                if (spacja == false)
                {
                    transform.localScale = new Vector3(3, 3, 3);
                    spacja = true;
                }else
                    {
                    transform.localScale = new Vector3(1, 1, 1);
                    spacja = false;
                    }

            }

        
        
        Debug.Log("Mouse position: " + Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            Debug.Log("Left mouse button has been pressed");
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Mouse position: " + Input.mousePosition);
        Debug.Log("Mouse in world position: " + worldPos);
        */
    }

    /*
    private void OnMouseEnter()
    {
        Debug.Log("Mouse entering over object");
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse leaving object");
    }
    private void OnMouseDrag()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(worldPos.x, worldPos.y, 0);
    }
    */
}

