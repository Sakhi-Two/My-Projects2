package csc2a.designpatterns;

import csc2a.model.Enemy;
import csc2a.model.Flag;
import csc2a.model.Player;
import csc2a.model.Road;

/**
 * 
 * AbstractVisitor interface
 * Used to define all of the render functions for your different GameObjects
 * @author  <YOUR DETAILS HERE>
 *
 */
public interface iRenderVisitor {
	/* TODO: render(YourGameObjectA a); method */
	public void render(Player p);
	
	/* TODO: render(YourGameObjectB b); method */
	public void render(Enemy e);
	// ...
	
	/* TODO: render(YourGameObjectC c); method */
	public void render(Road r);

	/* TODO: render(YourGameObjectC d); method */
	public void render(Flag f);
}
