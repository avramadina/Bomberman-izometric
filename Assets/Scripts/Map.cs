using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

public int width;
public int height;

private GameObject wall_prefab;
private GameObject breakable_prefab;
private GameObject startpos_prefab;
private GameObject floor_prefab;
private GameObject goal_prefab;
private GameObject door_prefab;
private GameObject powerup_prefab;
private GameObject Map_parent;

private int start_poses;

private Blocks[,] array_representation;

public void construct(int _start_poses, int x, int y, GameObject parent){
    
    
    start_poses = _start_poses;
    Map_parent = parent;
    
    startpos_prefab = (GameObject) Resources.Load("Startpos",typeof(GameObject));
   
   breakable_prefab = (GameObject) Resources.Load("Breakable", typeof(GameObject));

    door_prefab = (GameObject) Resources.Load("Door",typeof(GameObject));
    
    goal_prefab = (GameObject) Resources.Load("Goal",typeof(GameObject));

    floor_prefab = (GameObject) Resources.Load("Floor",typeof(GameObject));
    
    wall_prefab = (GameObject) Resources.Load("Wall",typeof(GameObject));
    
    
    if (x <= 2){
        x = 2;
    }
    if( y <= 2){
        y = 2;
    }

    if(_start_poses >= 7){
        start_poses = 7;
    }

     width = x;
    height = y;

    array_representation = new Blocks[x,y];


    create_map(x,y);
}

public bool is_walkable(int x, int y){
   
    return array_representation[x,y] != Blocks.Wall;
}

private void create_map(int x, int y){
    
    GameObject t = new_instance(1, 0, y/2 +  (y % 2), startpos_prefab);
    t.GetComponent<startpos_script>().player_controller = true;

    array_representation[1, y/2] = Blocks.Startpos;

    if(start_poses > 1){
    new_instance(1, 0, y-2, startpos_prefab);
    array_representation[1, y-2] = Blocks.Startpos;
    
    if(start_poses > 2){
   
     new_instance(1, 0, 1, startpos_prefab);
    array_representation[1, 1] = Blocks.Startpos;

     if(start_poses > 3){
    new_instance(x-2, 0, y-2, startpos_prefab);
    array_representation[x-2, y-2] = Blocks.Startpos;
    if(start_poses > 4){
    new_instance(x-2, 0, 1, startpos_prefab);
    array_representation[x-2, 1] = Blocks.Startpos;
   
    if(start_poses > 5){
        new_instance(x/2, 0, 1, startpos_prefab);
    array_representation[(x)/2, 1] = Blocks.Startpos;
    }
    if(start_poses > 6){
        new_instance(x/2, 0, y-2, startpos_prefab);
    array_representation[(x)/2, y-2] = Blocks.Startpos;
    }
    if(start_poses > 7){           
        new_instance(x-2, 0, y/2, startpos_prefab);
    array_representation[x-2, y/2] = Blocks.Startpos;
    }
    }
     }
    }
    }

    for(int i_x = 0; i_x < x; i_x++){
        for(int i_y = 0; i_y < y; i_y++){

        
            new_instance(i_x, -1, i_y, floor_prefab);
        
            if(i_x == 0 || i_x == x -1 || i_y == 0 || i_y == y -1){
        
          
            if(i_y == y/2 && i_x == x -1){
                array_representation[i_x, i_y] = Blocks.Door;
                 new_instance(i_x, 0, i_y, door_prefab);
                 new_instance(i_x+1, 0, i_y, goal_prefab);
              
            } else {
            array_representation[i_x, i_y] = Blocks.Wall;
            new_instance(i_x, 0, i_y, wall_prefab);
           
            }

            } else {

             
                 if(i_x % 2 == 0 && i_y % 2 == 0 && i_x != x-2 && i_y != y-2){
             
                 array_representation[i_x, i_y] = Blocks.Wall;
                 new_instance(i_x, 0, i_y, wall_prefab);
                 } else {

               
                if(!start_next_to(i_x, i_y)){
                  array_representation[i_x, i_y] = Blocks.Breakable;
                new_instance(i_x, 0, i_y, breakable_prefab);
                
                }
                }
            }
        } 
    }
}

  private bool start_next_to(int x, int y){
   if( array_representation[x-1, y] == Blocks.Startpos){
       return true;
   }
   if( array_representation[x+1, y] == Blocks.Startpos){
       return true;
   }
   if( array_representation[x, y+1] == Blocks.Startpos){
       return true;
   }
   if( array_representation[x, y-1] == Blocks.Startpos){
       return true;
   }
   if( array_representation[x, y] == Blocks.Startpos){
       return true;
   }
   if( array_representation[x-1, y-1] == Blocks.Startpos){
       return true;
   }
   if( array_representation[x+1, y+1] == Blocks.Startpos){
       return true;
   }
   return false;
        }


private GameObject new_instance(int x, int y, int z, GameObject prefab){
   GameObject temp_floor = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity) ; 
    temp_floor.transform.SetParent(Map_parent.transform); 
    return temp_floor;
}

}
