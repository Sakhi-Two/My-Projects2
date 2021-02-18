/**
 * 
 */
package csc2a.model;

import java.util.regex.Pattern;

import csc2a.designpatterns.iRenderVisitor;



/**
 * @author SAKHILE
 *
 */
public class Enemy extends GameObject {
	/* TODO: JavaDoc comment */
	public static boolean check(String line)
	{
		/* TODO: Regular Expression */
		//05 945:430
		//d+/s+[0-9:]+
		Pattern pattern = Pattern.compile("d+/s+[0-9:]+");
		/* TODO: Match line to pattern */
		
		return pattern.matcher(line).matches();/* TODO: return a boolean (it matches: true or false) */
	}
	private int enemyID;

	public Enemy() {
		super();
		
	}

	@Override
	public void accept(iRenderVisitor visitor) {
		visitor.render(this);
		
	 huntRight();
         
		
	}
	
	public int getEnemyID() {
		return enemyID;
		
	}
	
	public void huntRight() {
		
		this.setLocation(getXLocation()+0.8, getYLocation());
	
	}
	
	public void huntLeft() {
		
		this.setLocation(getXLocation()-0.8, getYLocation());
		
	}
	
	

}
