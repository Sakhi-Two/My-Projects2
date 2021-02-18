/**
 * 
 */
package csc2a.model;

import csc2a.designpatterns.iRenderVisitor;

/**
 * @author SAKHILE
 *
 */
public class Player extends GameObject{
	private int health;
	
	public Player(int h) {
		super();
		health = h;
	}

	@Override
	public void accept(iRenderVisitor visitor) {
		// TODO Auto-generated method stub
		visitor.render(this);
		
	}

	public int getHealth() {
		return health;
	}

	
}
