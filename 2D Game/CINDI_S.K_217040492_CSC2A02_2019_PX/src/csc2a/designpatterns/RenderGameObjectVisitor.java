package csc2a.designpatterns;

import csc2a.model.Enemy;
import csc2a.model.Flag;
import csc2a.model.Player;
import csc2a.model.Road;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;


/**
 * ConcreteVisitor class
 * Used to visit each GameObject and render them onto the GameCanvas
 * @author  <YOUR DETAILS HERE>
 *
 */
public class RenderGameObjectVisitor implements iRenderVisitor{
	
	//Attributes
	GraphicsContext gc = null;

	
	/**
	 * Mutator for the GraphicsContext from the GameCanvas
	 * Used to set gc so the Visitor can draw things on the Canvas
	 * @param gc the GraphicsContext from the GameCanvas
	 */
	public void setGraphicsContext(GraphicsContext gc) {
		this.gc = gc;
	}

	@Override
	public void render(Player p) {
		// TODO Auto-generated method stub
		gc.setFill(Color.BLUE);
		gc.fillOval(p.getXLocation(),p.getYLocation(), 20, 20);
	}

	@Override
	public void render(Enemy e) {
		// TODO Auto-generated method stub
		
		gc.setFill(Color.RED);
		gc.fillOval(e.getXLocation(),e.getYLocation(), 20, 20);
		//
		gc.setFill(Color.RED);
		gc.fillOval(e.getXLocation(),150, 20, 20);
		
		gc.setFill(Color.RED);
		gc.fillOval(300,150, 20, 20);
		//
		gc.setFill(Color.RED);
		gc.fillOval(e.getXLocation(),230, 20, 20);
		
		gc.setFill(Color.RED);
		gc.fillOval(240,443, 20, 20);
		//
		gc.setFill(Color.RED);
		gc.fillOval(e.getXLocation(),370, 20, 20);
		
		gc.setFill(Color.RED);
		gc.fillOval(638,233, 20, 20);
		//
		gc.setFill(Color.RED);
		gc.fillOval(e.getXLocation(), 430 , 20, 20);
		
		gc.setFill(Color.RED);
		gc.fillOval(740,333, 20, 20);
		//
		gc.setFill(Color.RED);
		gc.fillOval(e.getXLocation(),550, 20, 20);
		/*TranslateTransition trans = new TranslateTransition();
		trans.setDuration(Duration.seconds(5));
		trans.setToX(700);
		trans.setAutoReverse(true);
		trans.setCycleCount(Animation.INDEFINITE);
		trans.setNode
		trans.play();*/
		
		
	}

	@Override
	public void render(Road r) {
		// TODO Auto-generated method stub
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(r.getXLocation(), r.getYLocation(), 1000, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(r.getXLocation(), r.getYLocation(), 1000, 20);
		//other
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(80, 600, 100, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(80,600, 100, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(150,500, 167, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(150,500, 167, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(350, 600, 300, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(350,600, 300, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(720, 600, 100, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(720,600, 100, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(575, 520, 100, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(575,520, 100, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(850, 520, 150, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(850,520, 150, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(450, 400, 400, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(450,400, 400, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(1,350 , 300, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(1,350, 300, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(200, 277, 200, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(200,277, 200, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(540, 300, 120, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(540,300, 120, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(700, 250, 200, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(700,250, 200, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(410, 200, 250, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(410,200, 250, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(2, 177, 200, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(2,177, 200, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(200, 100, 100, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(200,100, 100, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(900, 35, 200, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(900,35, 200, 20);
		//
		gc.setFill(Color.CHOCOLATE);
		gc.fillRect(777,100 , 100, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(777,100, 100, 20);
		//
		 gc.setFill(Color.CHOCOLATE);
		gc.fillRect(460,130 , 120, 20);
		gc.setStroke(Color.DARKGREEN);
		gc.strokeRect(460,130, 120, 20);
	
	}

	@Override
	public void render(Flag f) {
		// TODO Auto-generated method stub
				gc.setFill(Color.GREENYELLOW);
				gc.fillRect(f.getXLocation(),f.getYLocation(), 20, 20);
				gc.setStroke(Color.CHOCOLATE);
				gc.strokeRect(f.getXLocation(), f.getYLocation(), 20, 20);
				
				
	}
	
	
	
	

}
