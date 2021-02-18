package csc2a.ui;

import java.io.File;



import csc2a.model.GameObjectContainer;
import csc2a.util.KMBuffer;
import javafx.animation.AnimationTimer;
import javafx.scene.control.Button;
import javafx.scene.control.Menu;
import javafx.scene.control.MenuBar;
import javafx.scene.control.MenuItem;
import javafx.scene.input.KeyCode;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.scene.text.Text;
import javafx.stage.FileChooser;


/**
 * 
 * GamePane provides a custom container to manage all game interactions
 * and host the GameCanvas
 * @author <YOUR DETAILS HERE>
 *
 */
public class GamePane extends StackPane{
	
	//Attributes
	private GameCanvas canvas; //You need the canvas so the visitor can draw on it
	private AnimationTimer gameTimer; //Used if you want to make a game that runs at 60 frames per second
	private int set = 1;
	private GameObjectContainer items = new GameObjectContainer();
	/**
	 * Default constructor
	 */
	public GamePane() {
		super();
		
		MenuBar menubar = new MenuBar();
		Menu menu = new Menu("File");
		menubar.getMenus().add(menu);
		MenuItem mit = new MenuItem("Open File");
		menu.getItems().add(mit);
		VBox vbox = new VBox();
		
		
		mit.setOnAction(event -> {
			FileChooser fc = new FileChooser();
			fc.setInitialDirectory(new File("./data"));
			File file = fc.showOpenDialog(null);
			if(file != null) {
				//items = GameFileHandler.readEnemies(file);
			}
		});
		
		Button b1 = new Button("Start Game");
		Text t1 = new Text();
		t1.setText("BLUE CIRCLE -> Player");
		Text t2 = new Text();
		t2.setText("RED CIRCLE -> Enemy");
		Text t3 = new Text();
		t3.setText("GREEN SQUARE -> Flag");
		Text t4 = new Text();
		t4.setText("UP ARROW -> Move Up");
		Text t5 = new Text();
		t5.setText("DOWN ARROW -> Move Down");
		Text t6 = new Text();
		t6.setText("LEFT ARROW -> Move Left");
		Text t7 = new Text();
		t7.setText("RIGHT ARROW -> Move Right");
		Text t8 = new Text();
		t8.setText("Avoid enemies and get flag in time(before 1500 seconds)");
		b1.setOnAction(event -> {
			//Create the canvas to draw on
			canvas = new GameCanvas();	
			//Bind the width and height so the canvas resizes with window		
			//canvas.widthProperty().bind(this.widthProperty());
			//canvas.heightProperty().bind(this.heightProperty());
			
			/* TODO: Construct your GamePane as you see fit */
					
			
			/* TODO: Do you game logic (See Animation Timer below) */
			
			/*
			 * Animation Timer 
			 * 
			 * Animation timer is only needed if you want to have a game that runs at a set frame rate (~60fps) 
			 * 
			 * You can safely remove the ApplicationTimer if you would prefer to rather implement your own 
			 * event handlers to drive your game logic (then setup your event handlers for events such as: 
			 * 			this.setOnKeyPressed();
			 * 			this.setOnKeyReleased();		
			 * 			this.setOnMouseMoved();		
			 * 			this.setOnMousePressed();
			 * 			this.setOnMouseReleased();
			 * 			this.setOnMouseEntered();
			 * 			this.setOnMouseExited();
			 * 			this.setOnMouseDragged();  )
			 * 
			 (i.e. This object V V V ) */
			gameTimer = new AnimationTimer() {

				@Override
				public void handle(long now) {
					canvas.requestFocus(); //This is important so that the canvas (with all the event handlers) intercepts the Key and Mouse events
					
					/*
					 * Do your game logic here
					 */
					
					/* 
					 * HINT: Look up AnimationTimer
					 * See: https://docs.oracle.com/javase/8/javafx/api/javafx/animation/AnimationTimer.html
					 * it provides a handle method to perform operations 
					 * roughly 60 times per second (@ 60fps)
					 * 
					 * 
					 * Note: if you use the Event Handler Code from the KMBuffer to test for events such as:
					 * 
					 * 	Key pressed: 
					 * 		KMBuffer.isKeyPressed(KeyCode.UP); //.UP is for the Up Arrow Key
					 * 		For more see: https://docs.oracle.com/javase/8/javafx/api/javafx/scene/input/KeyCode.html */
					 System.out.println("Up arrow is pressed: " + KMBuffer.isKeyPressed(KeyCode.UP)); 
					 
					/*  Mouse in window: 
					 *  	KMBuffer.isMouseInWindow(); */
					 System.out.println("Mouse is in window: " + KMBuffer.isMouseInWindow());   
					
					/*  Mouse location: 
					 *  	KMBuffer.getMouseNodeLocation(); //OR .getMouseSceneLocation() OR .getMouseScreenLocation() (but you shouldn't really need this one) */
					 System.out.println("Mouse location relative to canvas: (" + KMBuffer.getMouseNodeLocation().getX() + "," + KMBuffer.getMouseNodeLocation().getY() + ")");   
					
					 /*  Mouse button pressed:
					 *  	KMBuffer.isLeftMousePressed();
					 *  	KMBuffer.isRightMousePressed();
					 *  	KMBuffer.isMiddleMousePressed(); */
					 System.out.println("Left mouse pressed: " + KMBuffer.isLeftMousePressed()); 
					 
					
					/* TODO: Set the GameObjects that your GameCanvas needs to draw */
					
					/* TODO: Redraw GameCanvas() */
			
					 if(set == 1) {
						 canvas.setItems();
						 set++;
					 }
					 
					 //canvas.addEnemies();
					 canvas.redrawCanvas();
				}
			};
			gameTimer.start();
			this.getChildren().add(canvas);
		});

		
		
		
		/* TODO: Finish setting up your GamePane */
		
		vbox.getChildren().addAll(menubar,b1,t1,t2,t3,t4,t5,t6,t7,t8);
		this.getChildren().add(vbox);
		
	}	
}
