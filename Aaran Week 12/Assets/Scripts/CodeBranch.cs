#define SOME_SYMBOLS
#if SOME_SYMBOLS
// Symbol is already defined
#else 
//symbol is unfined
#endif

#undef SOME_SYMBOLS
#if SOME_SYMBOLS
// Symbol is already defined
#else 
//symbol is undefined
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CodeBranch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
