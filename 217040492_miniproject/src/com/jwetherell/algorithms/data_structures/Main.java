/**
 * 
 */
package com.jwetherell.algorithms.data_structures;


import  javafx.application.Application;
import javafx.stage.Stage;
import javafx.scene.*;

/**
 * @author csakh
 *
 */
public class Main extends Application{

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
            launch(args);
	}

	@Override
	public void start(Stage stage) throws Exception {
		// TODO Auto-generated method stub
		 GraphPane gp = new GraphPane();
		 stage.setTitle("PayCheck");
		 Scene scene = new Scene(gp,900,750);
		 stage.setScene(scene);
		 stage.show();
		 
	}

}
