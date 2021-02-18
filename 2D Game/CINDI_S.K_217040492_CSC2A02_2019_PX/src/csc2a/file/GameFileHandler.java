package csc2a.file;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.StringTokenizer;

import csc2a.model.CharacterFactory;
import csc2a.model.Enemy;
import csc2a.model.GameObject;
import csc2a.model.GameObjectContainer;

/**
 * 
 * Class to handle all interactions with files
 * @author <YOUR DETAILS HERE>
 *
 */

public class GameFileHandler {
	/* TODO: Methods to handle text files */
	/* TODO: JavaDoc */
	
	public static GameObjectContainer readEnemies(File eFile)
	{
		
		/* TODO: Create ArrayList for items */
		GameObjectContainer obc = new GameObjectContainer();
		CharacterFactory cf = new CharacterFactory();
		
		/* TODO: Create Scanner */
		Scanner sc = null;
		
		/* TODO: Read each line of the file      */
		/* 	TODO: Validate using validate method */
		/* 	TODO: Create correct instance        */
		/* 	TODO: Add to ArrayList               */
		/* 	TODO: Handle problems                */
		/* TODO: Free resources                  */
		try {
			sc = new Scanner(eFile);
			while(sc.hasNext()) {
				String line = sc.nextLine();
				if(Enemy.check(line)) {
			
					StringTokenizer tk = new StringTokenizer(line,"\t:"); 
					int x = Integer.parseInt(tk.nextToken());
					int y = Integer.parseInt(tk.nextToken());
				//	int id = Integer.parseInt(tk.nextToken());
		
					for(int i = 3;i <obc.getSize();i++) {
					//	obc.addGameObject(cf.produceEnemy(x,y,id));
						obc.getObject(i).setLocation(x, y);
					}
					
					
					
				}else {
					System.err.println("Does not match line: " + line);
				}
				
			}
			
		}catch(FileNotFoundException ex) {
			
		}finally {
			if(sc != null) {
				sc.close();
			}
		}
			
		/* TODO: Return ArrayList */
		return obc;
	}
	/* TODO: Methods to handle binary files */
}
