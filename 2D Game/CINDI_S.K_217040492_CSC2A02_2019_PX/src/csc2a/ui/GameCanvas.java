package csc2a.ui;

import java.util.ArrayList;

import csc2a.designpatterns.RenderGameObjectVisitor;
import csc2a.model.CharacterFactory;
import csc2a.model.GameObjectContainer;
import csc2a.util.KMBuffer;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.image.Image;
import javafx.scene.input.KeyCode;
import javafx.scene.paint.Color;

/**
 * 
 * Canvas used to render all of your GameObjects using the Visitor
 * This is the Client in the Visitor Design Pattern
 * @author  <YOUR DETAILS HERE>
 *
 */
public class GameCanvas extends Canvas{
	
	//Attributes
	private RenderGameObjectVisitor visitor;
	private GraphicsContext gc;
	private Image image;
	private int seconds;
	/* TODO: Store all of your GameObjects (Using GameObjectContainers) here */
	GameObjectContainer obc = new GameObjectContainer();
	
	/**
	 * Default Constructor
	 */
	public GameCanvas() {
		/*
		 * Optional (but makes your life easier)
		 * 
		 * 
		 * Set up KMBuffer as the event "listener"
		 * (You can remove this line if you prefer to handle your own events)
		 * 
		 */
		setUpEventListeners();
		visitor = new RenderGameObjectVisitor();
		this.setWidth(1000);
		this.setHeight(700);
		/*
		 * End Optional
		 */
	}
	
	/* TODO: Set your GameObjects and redrawCanvas() */
	public void setItems()
	{
		CharacterFactory cf = new CharacterFactory();
		//
		obc.addGameObject(cf.producePlayer(100));
		obc.getObject(0).setLocation(30,660);
		//
		obc.addGameObject(cf.produceFlag());
		obc.getObject(1).setLocation(970,0);
		//
		obc.addGameObject(cf.produceRoad());
		obc.getObject(2).setLocation(3,680);
		//
		obc.addGameObject(cf.produceEnemy());
		obc.getObject(3).setLocation(6, 55);
	
		
		/* TODO: (OPTION B repaint canvas here (if you didn't do it in MonitorPane)*/
		
	}
	/*public void addEnemies() {
		CharacterFactory cf = new CharacterFactory();
		if((int)(Math.random()*70+1) < 10) {
			obc.addGameObject(cf.produceEnemy());
			obc.getObject(obc.getSize()-1).setLocation(0,10+ Math.random() * 100 +1);
		}
	}
	
	
	/**
	 * Method used to redraw the canvas whenever called
	 */
	public void redrawCanvas(){
		/* TODO: Get GraphicsContext */
	    gc = this.getGraphicsContext2D();
	  
	   // gc.drawImage(getImage(), 0, 0,this.getWidth() ,this.getHeight() );
		gc.setFill(Color.BURLYWOOD);
		gc.fillRect(0, 0, this.getWidth(), this.getHeight());
		
		gc.setStroke(Color.BLACK);
		gc.strokeText("time : ",10,20);
		gc.setStroke(Color.BLACK);
		gc.strokeText(String.valueOf(seconds), 40, 20);
		/* TODO: Set Visitor's GraphicsContext */
		visitor.setGraphicsContext(gc);
		
		/* TODO: Iterate through ALL GameObjects (Using GameObjectContainers) */
			/* TODO: Get EACH GameObject to accept() the Visitor */
		for(int x = 0; x < obc.getSize();x++) {
			obc.getObject(x).accept(visitor);
			
		}
		
		 seconds++;
		if(seconds == 1500) {
			
			 obc.removeGameObject(0);
			 gc.setStroke(Color.BLACK);
			  gc.strokeText("GAME OVER -> RAN OUT OF TIME",100 ,10 );
			  
		}else if(obc.getObject(0).getXLocation()==970 && obc.getObject(0).getYLocation()==0) {
			obc.removeGameObject(1);
			 gc.setStroke(Color.BLACK);
			  gc.strokeText("IF AT FLAG LOCATION YOU WON / NOT AT FLAG LOCATION TIMES OUT",100 ,10 );
		}
	}
	
	/**
	 * Method to set that the KMBuffer is responsible for handling key and mouse events
	 * (Use the KMBuffer's static methods in your GamePane to check for key and mouse events)
	 */
	private void setUpEventListeners() {
		/*--------------------------------------------------------------------
		 * 
		 * Event Handler Code
		 * 
		 * Code to set up the Keyboard and Mouse Events to be handled by the 
		 * provided KMBuffer in the util package
		 * 
		 * Note: If you want to, you can remove this code and handle events
		 * 		 yourself either in this Canvas or in your GamePane
		 * 
		 *--------------------------------------------------------------------*/
		/*
		 * Set the event listeners to handle the key press and release events in the KMBuffer
		 */
		this.setOnKeyPressed((event)    -> { KMBuffer.handleKeyPressed(event);  
			if(KMBuffer.isKeyPressed(KeyCode.UP)) {
				obc.getObject(0).moveUp();
				
			}else if(KMBuffer.isKeyPressed(KeyCode.DOWN)){
				obc.getObject(0).moveDown();
			}else if(KMBuffer.isKeyPressed(KeyCode.RIGHT)) {
				obc.getObject(0).moveRight();
			}else if(KMBuffer.isKeyPressed(KeyCode.LEFT)) {
				obc.getObject(0).moveLeft();
			}
		
		});
		this.setOnKeyReleased((event)   -> { KMBuffer.handleKeyReleased(event);   });
		
		/*
		 * Set the event listeners to handle the mouse events in the KMBuffer
		 */
		this.setOnMouseMoved((event)    -> { KMBuffer.handleMouseMoved(event);    });		
		this.setOnMousePressed((event)  -> { KMBuffer.handleMousePressed(event);  });
		this.setOnMouseReleased((event) -> { KMBuffer.handleMouseReleased(event); });
		this.setOnMouseDragged((event)  -> { KMBuffer.handleMouseDragged(event);  });
		this.setOnMouseEntered((event)  -> { KMBuffer.handleMouseEntered(event);  });
		this.setOnMouseExited((event)   -> { KMBuffer.handleMouseExited(event);   });
		
		/*this.setOnMouseClicked(event -> {
		}); //You need to add an event handler to deal with this event in this Class*/
		
		
		
		}
        
	
	/*public void hunt() {
		Enemy e = new Enemy(0,0,0);

		if(obc.getObject(3).getXLocation()== 6) {
			 
			e.huntRight();
		}else if(obc.getObject(3).getXLocation() == 700) {
			e.huntLeft();
		}
	}
	
	
		
		/*--------------------------------------------------------------------
		 * 
		 * End of Event Handler Code
		 * 
		 *--------------------------------------------------------------------*/
	
}
