using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Transform mainPanel;
    public GameObject nodePrefab;
    public List<Node> nodes;
    public Block blockPrefab;


    // Start is called before the first frame update
    void Start()
    {
        nodes = new List<Node>();
        for (int i = 0; i < 16; i++)
        {
            GameObject node = Instantiate(nodePrefab, mainPanel);
            nodes.Add(node.GetComponent<Node>());
        }
        SpawnBlocks(2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
 
    
    }


    public void SpawnBlocks(int amount=1)
    {
        List<Node> freeNodes=nodes.Where(n=>n.occupiedBlock==null).OrderBy(b=>Random.value).ToList();
        foreach (var node in freeNodes.Take(amount))
        {
            var block=Instantiate(blockPrefab, node.pos, Quaternion.identity);
            node.occupiedBlock = block;
            block.transform.parent = mainPanel;
            block.transform.position = node.pos;
        }

    }




}


