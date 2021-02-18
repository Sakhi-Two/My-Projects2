package csc2a.model;

import csc2a.designpatterns.iRenderable;
import javafx.geometry.Point2D;

/*
 * 
 * You may edit this class as you see fit to suit your game's requirements
 * 
 */

/**
 * The class from which all of your game objects must inherit
 * Extend this class for all of your custom game objects
 * @author Mr Greaves
 */
public abstract class GameObject implements iRenderable{
	
	//Attributes
	private Point2D location; //Stores the (x,y) coordinate of the GameObject in the world	
	
	/**
	 * Default Constructor
	 */
	public GameObject() {
		location = new Point2D(0, 0);
	}
	
	/**
	 * Parameterized Constructor
	 * @param x x-coord of the GameObject
	 * @param y y-coord of the GameObject
	 */
	public GameObject(int x, int y) {
		location = new Point2D(x, y);
	}
	
	/**
	 * Parameterized Constructor
	 * @param location Point2D representing the GameObject's location
	 */
	public GameObject(Point2D location) {
		this.location = location;
	}
	
	/**
	 * Accessor for the GameObject's location
	 * @return Location of GameObject
	 */
	public Point2D getLocation() {
		return location;
	}
	
	/**
	 * Accessor for the GameObject's X location
	 * @return X coordinate 
	 */
	public double getXLocation() {
		return location.getX();
	}
	
	/**
	 * Accessor for the GameObject's Y location
	 * @return Y coordinate
	 */
	public double getYLocation() {
		return location.getY();
	}
	
	
	/**
	 * Mutator for GameObject's location
	 * @param newLocation Point2D representing location
	 */
	public void setLocation(Point2D newLocation) {
		location = newLocation;
	}
	
	/**
	 * Mutator for GameObject's location
	 * @param d new x-coord of GameObject
	 * @param e new y-coord of GameObject
	 */
	public void setLocation(double d, double e) {
		location = new Point2D(d, e);
	}
	
	
	
	public void moveUp() {
		// TODO Auto-generated method stub
		this.setLocation(getXLocation(), getYLocation()-10);
	}


	public void moveDown() {
		// TODO Auto-generated method stub
		this.setLocation(getXLocation(), getYLocation()+10);
	}
	
	public void moveRight() {
		// TODO Auto-generated method stub
		this.setLocation(getXLocation()+10, getYLocation());
	}
	
	public void moveLeft() {
		// TODO Auto-generated method stub
		this.setLocation(getXLocation()-10, getYLocation());
	}
	
	
	/* 
	 * Note: All classes that extend this class MUST implement 
	 * the accept(iRenderVisitor visitor) method from iRenderable
	 */
}

/*
 * 
 * You may edit this class as you see fit to suit your game's requirements
 * 
 */
