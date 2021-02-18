/**
 * 
 */
package com.jwetherell.algorithms.data_structures;


import javafx.scene.layout.*;
import javafx.scene.paint.Color;
import javafx.scene.control.*;

import java.util.ArrayList;
import java.util.Collection;
import com.jwetherell.algorithms.data_structures.Graph.Edge;
import com.jwetherell.algorithms.data_structures.Graph.Vertex;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;

/**
 * @author csakh
 *
 */
public class GraphPane extends StackPane {
	
	private Graph<String> myGraph = null; 
	private Process<String> p = null;
	private Collection<Vertex<String>> HouseTowerVs = null;
	private Collection<Edge<String>> resourceAccess = null;
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public GraphPane() {
		    //Create Graph
		    p = new Process<>();
		    HouseTowerVs = p.readVfile();
		    resourceAccess = p.createEdge();
		    myGraph = p.createGraph(HouseTowerVs,resourceAccess);
		    //Layout choice
		    BorderPane b = new BorderPane();
		    GridPane gp = new GridPane();
			gp.setVgap(5);
	    	gp.setHgap(5);
	    	gp.setStyle("-fx-padding: 10;" +"-fx-border-style: solid inside;" + "-fx-border-width: 2;" +"-fx-border-insets: 5;" + "-fx-border-radius: 5;" + "-fx-border-color: navy;");
			GridPane gp2 = new GridPane();
			gp2.setVgap(5);
	    	gp2.setHgap(5);
	    	gp2.setStyle("-fx-padding: 10;" +"-fx-border-style: solid inside;" + "-fx-border-width: 2;" +"-fx-border-insets: 5;" + "-fx-border-radius: 5;" + "-fx-border-color: navy;");
			
			b.setTop(gp);;
			b.setBottom(gp2);
			
			//Labels for nodes
			Label lbl0 = new Label("Response section");
			Label lbl00 = new Label("Response section");
			Label lbl0000 = new Label("Response section");
			//Buttons for user interaction
			Button btn1 = new Button("Get Current INFO");
			btn1.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
			btn1.setPrefWidth(200);
			//Text area
			TextArea t1 = new TextArea();
			t1.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
			t1.setPrefHeight(200);
			t1.setPrefWidth(300);
			TextArea t5 = new TextArea();
			t5.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
			t5.setPrefHeight(200);
			t5.setPrefWidth(300);
			TextArea t12 = new TextArea();
			t12.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
			t12.setPrefHeight(200);
			t12.setPrefWidth(300);
			//add children 
			gp.add(btn1, 0, 0);
			gp.add(lbl0, 0, 1);
			gp.add(lbl00, 1, 1);
			gp.add(lbl0000, 2, 1);
			gp.add(t1, 0,2);
			gp.add(t5, 1,2);
			gp.add(t12, 2,2);
			
			//Labels for nodes
			Label lbl000 = new Label("Visual representation");
			//Buttons for user interaction
			Button btn2 = new Button("DRAW VISUAL");
			btn2.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
			btn2.setPrefWidth(200);
			Button btn3 = new Button("Manage");
			btn3.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
			btn3.setPrefWidth(200);
			Button btn7 = new Button("Exit");
			btn7.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
			btn7.setPrefWidth(200);
			//Drawing space
			Canvas cv = new Canvas(850,300);
			GraphicsContext gc = cv.getGraphicsContext2D();
			gc.setFill(Color.NAVY);
			gc.fillRect(1, 1, 850, 300);
					
			//add children 
			gp2.add(lbl000, 0, 0);
			gp2.add(btn2, 0, 1);
			gp2.add(cv, 0, 2);
			gp2.add(btn3, 0,3);
			gp2.add(btn7, 0,4);
			
		    this.getChildren().add(b);
		
			//Shows existing household information
			btn1.setOnAction(e ->{
			    t1.setText("********************************************" 
			     +"\n"
				 +"[House&Resource | Units Payed]: "
				 +"\n"
			     + HouseTowerVs 
			     + "\n"
			     + "********************************************" );
			    t5.setText( "********************************************" 
					     +"\n"
					     +" [Power Supply | Cost] " 
					     + "\n"
					     + resourceAccess 
					     + "\n"
					     + "********************************************");
			});
			    
			
			//Displays graph based on existing info
			btn2.setOnAction(e -> {
				final int WH = 25;
				t12.appendText("\n" 
				+ "****************************************************"
				+ "\n"		
				+ "Household electricity supply monitor is created" 
				+ "\n" 
				+ "****************************************************");
				
				int mn = 20;
				int mx = 750;
				int mx2 =250;
				ArrayList<Integer> vsX = new ArrayList<>();
				ArrayList<Integer> vsY = new ArrayList<>();
				if(myGraph.getVertices().equals(HouseTowerVs)) {
					for(int v = 0; v < myGraph.getVertices().size();v++) {
						int locX = (int) (mn + Math.random() * (mx-mn));
						int locY =  (int) (mn + Math.random() * (mx2-mn));
						
							if(v <= 4) {
								gc.setFill(Color.CHOCOLATE);
								gc.fillOval(locX, locY, WH, WH);
								gc.setStroke(Color.WHITE);
								gc.strokeText(myGraph.getVertices().get(v).getValue() +" | " + " R" + myGraph.getVertices().get(v).getWeight(), locX, locY);
							}else {
								gc.setFill(Color.AQUA);
								gc.fillOval(locX, locY, WH, WH);
								gc.setStroke(Color.WHITE);
								gc.strokeText(myGraph.getVertices().get(v).getValue() , locX, locY);
								
							}   
							vsX.add(locX);
							vsY.add(locY);
					}
					
					 //Draw the edges
							for(int v =0;v < myGraph.getVertices().size();v++) {
								if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==0) {
									gc.setStroke(Color.AQUA);
									gc.setLineWidth(3);
								    gc.strokeLine(vsX.get(7),vsY.get(7),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==1) {
							    	  gc.setStroke(Color.AQUA);
									    gc.strokeLine(vsX.get(7),vsY.get(7),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==2) {
							    	  gc.setStroke(Color.AQUA);
									    gc.strokeLine(vsX.get(6),vsY.get(6),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==3) {
							    	  gc.setStroke(Color.AQUA);
									    gc.strokeLine(vsX.get(6),vsY.get(6),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==3) {
							    	  gc.setStroke(Color.AQUA);
									    gc.strokeLine(vsX.get(5),vsY.get(5),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==4) {
							    	  gc.setStroke(Color.AQUA);
									    gc.strokeLine(vsX.get(5),vsY.get(5),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==5) {
							    	  gc.setStroke(Color.AQUA);
									    gc.strokeLine(vsX.get(6),vsY.get(6),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==6) {
							    	  gc.setStroke(Color.AQUA);
									    gc.strokeLine(vsX.get(7),vsY.get(7),vsX.get(v),vsY.get(v));
							      }else if(myGraph.getVertices().indexOf(myGraph.getVertices().get(v))==7) {
							    	  gc.setStroke(Color.AQUA);
									  gc.strokeLine(vsX.get(5),vsY.get(5),vsX.get(v),vsY.get(v));
							      }
				       }
					 }
			});
			
			//Directs to next page, with update features.
			btn3.setOnAction(e ->{
				this.getChildren().clear();
				
				//Layout choice
				BorderPane bp = new BorderPane();
				GridPane g1 = new GridPane();
				g1.setVgap(5);
		    	g1.setHgap(5);
		    	g1.setStyle("-fx-padding: 10;" +"-fx-border-style: solid inside;" + "-fx-border-width: 2;" +"-fx-border-insets: 5;" + "-fx-border-radius: 5;" + "-fx-border-color: navy;");
				GridPane g2 = new GridPane();
				g2.setVgap(5);
		    	g2.setHgap(5);
		    	g2.setStyle("-fx-padding: 10;" +"-fx-border-style: solid inside;" + "-fx-border-width: 2;" +"-fx-border-insets: 5;" + "-fx-border-radius: 5;" + "-fx-border-color: navy;");
				GridPane g3 = new GridPane();
				g3.setVgap(5);
		    	g3.setHgap(5);
		    	g3.setStyle("-fx-padding: 10;" +"-fx-border-style: solid inside;" + "-fx-border-width: 2;" +"-fx-border-insets: 5;" + "-fx-border-radius: 5;" + "-fx-border-color: navy;");
				
				bp.setCenter(g2);
				bp.setLeft(g1);
				bp.setRight(g3);
				
				//G1 LAYOUT
				//Labels
		    	Label lbl1 = new Label("Household Name");
		    	Label lbl2 = new Label("Units Payed (in Rands)");
		    	Label lbl4 = new Label("Cost");
		    	Label lbl5 = new Label("From Pole");
		    	Label lbl6 = new Label("To Household");
		    	Label lbl12 = new Label("Checked Households");
		    	Label lbl13 = new Label("New Units Payed (in Rands)");
		    	
		    	
		    	//Text spaces for inputs and responses
				TextArea t2 = new TextArea();
				t2.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				t2.setPrefHeight(10);
				t2.setPrefWidth(200);
				TextArea t3 = new TextArea();
				t3.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				t3.setPrefHeight(10);
				t3.setPrefWidth(200);
				TextArea t7 = new TextArea();
				t7.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				t7.setPrefHeight(10);
				t7.setPrefWidth(200);
			    final ComboBox t8 = new ComboBox();
			    t8.getItems().addAll("PoleOne","PoleTwo","PoleThree");
				t8.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				t8.setPrefHeight(10);
				t8.setPrefWidth(200);
				 final ComboBox t9 = new ComboBox();
				 for(int v =0;v<myGraph.getVertices().size();v++) {
					 t9.getItems().addAll(myGraph.getVertices().get(v).getValue());
				 }
			     t9.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
			     t9.setPrefHeight(10);
				 t9.setPrefWidth(200);
				 final ComboBox c1 = new ComboBox();
			     c1.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
			     c1.setPrefHeight(10);
				 c1.setPrefWidth(200);
				 TextArea t15 = new TextArea();
				 t15.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				 t15.setPrefHeight(10);
				 t15.setPrefWidth(200);
				
				//Buttons for user interaction
				Button btn4 = new Button("ADD HOUSEHOLD");
				btn4.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn4.setPrefWidth(200);
				Button btn5 = new Button("REMOVE HOUSEHOLD");
				btn5.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn5.setPrefWidth(200);
				Button btn6 = new Button("EDIT HOUSEHOLD");
				btn6.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn6.setPrefWidth(200);
				Button btn8 = new Button("ADD POWER SUPPLY");
				btn8.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn8.setPrefWidth(200);
				Button btn9 = new Button("CUT POWER SUPPLY");
				btn9.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn9.setPrefWidth(200);
				Button btn11 = new Button("Quit");
				btn11.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn11.setPrefWidth(200);
				Button btn13 = new Button("CHECK EACH HOUSEHOLD");
				btn13.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn13.setPrefWidth(200);
				
				//add children 
				g1.add(lbl1, 0, 0);
				g1.add(t2, 0, 1);
				g1.add(lbl2, 0,2);
				g1.add(t3, 0,3 );
				g1.add(btn4, 0, 4);
				g1.add(btn13, 0, 5);
				g1.add(lbl12, 0, 6);
				g1.add(c1, 0, 7);
				g1.add(lbl13, 0, 8);
				g1.add(t15, 0, 9);
				g1.add(btn6, 0, 10);
				g1.add(btn5, 0, 11);
				g1.add(lbl4, 0, 12);
				g1.add(t7, 0, 13);
				g1.add(lbl5, 0, 14);
				g1.add(t8, 0, 15);
				g1.add(lbl6, 0, 16);
				g1.add(t9, 0, 17);
				g1.add(btn8, 0, 18);
				g1.add(btn9, 0, 19);
				g1.add(btn11, 0, 20);
			
				
				//G2 LAYOUT
				//Labels
				Label lbl3 = new Label("Response section");
				Label lbl7 = new Label("Response section");
				Label lbl9 = new Label("Current info");
				//Text spaces for inputs and responses
				TextArea t4 = new TextArea();
				t4.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				t4.setPrefHeight(200);
				t4.setPrefWidth(400);
				TextArea t10 = new TextArea();
				t10.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				t10.setPrefHeight(200);
				t10.setPrefWidth(400);
				TextArea t11 = new TextArea();
				t11.setStyle("-fx-border-color: navy;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;");
				t11.setPrefHeight(200);
				t11.setPrefWidth(400);
				//Add Children
				g2.add(lbl9, 0, 0);
				g2.add(t11, 0, 1);
				g2.add(lbl3, 0, 2);
				g2.add(t4, 0, 3);
				g2.add(lbl7, 0, 4);
				g2.add(t10, 0, 5);
				
				
				//G3 LAYOUT
				//Labels
				Label lbl8 = new Label("Visual Representation");
				//Drawing space
				Canvas cv2 = new Canvas(400,620);
				GraphicsContext gc2 = cv2.getGraphicsContext2D();
				gc2.setFill(Color.NAVY);
				gc2.fillRect(1, 1,400, 620);
				//Buttons for user interaction
				Button btn10= new Button("DRAW VISUAL");
				btn10.setStyle("-fx-background-color:navy;" + "-fx-text-fill: white;" + "-fx-border-color: white;"+"-fx-border-style: solid inside;"+ "-fx-border-radius: 5;"); 
				btn10.setPrefWidth(200);
				//Add Children
				g3.add(lbl8, 0, 0);
				g3.add(btn10, 0, 1);
				g3.add(cv2, 0, 2);

	             //Add root			
				this.getChildren().add(bp);
				
				//Get information from previous page
				t11.setText(
						 "********************************************" 
					     +"\n"
					     +" [Power Supply | Cost] " 
					     + "\n"
					     + resourceAccess 
					     + "\n"
					     + "********************************************");
				
				//Actions
				//Add household
				btn4.setOnAction(c-> {
					String name = t2.getText();
					int payed = Integer.parseInt(t3.getText());
					p.addVertex(myGraph, name, payed);
	                t4.setText(
	    			"****************************"
	    			+"\n"
	    			+"Added Household: " + name
	    			+"\n"
	    			+"****************************"
	    			+"\n"
	    			+"Updated Households"
	    			+"\n"
	    			+"*****************************"
	    			+"\n"
	    			+ myGraph
	    			+"\n"
	    			+"*****************************");	
	                t3.clear();
	                t2.clear();
	                t9.getItems().clear();
	                for(int v =0;v<myGraph.getVertices().size();v++) {
						 t9.getItems().addAll(myGraph.getVertices().get(v).getValue());
					 }
	                
				});
				
				// Check households
				btn13.setOnAction(c ->{
					  ArrayList<Vertex<String>> seen = p.BFTraverse(myGraph,myGraph.getVertices().get(0));
					  for(int s=0;s<seen.size();s++) {
						  c1.getItems().addAll(seen.get(s).getValue());
					  }
				});
				
				//Remove household
				btn5.setOnAction(c-> {
					 /* ArrayList<Vertex<String>> seen = p.BFTraverse(myGraph,myGraph.getVertices().get(0));
					  for(int s=0;s<seen.size();s++) {
						  if(seen.get(s).getWeight() < seen.get(s).getEdge(seen.get(s)).getCost()) {
							  
						  }
					  }*/
					  
					            String name = (String) c1.getValue();
								p.removeVertex(myGraph, name);
								t4.setText(
										"****************************"
										+"\n"
										+"Removed Household: " + name
										+"\n"
										+"****************************"
										+"\n"
										+"Updated Households"
										+"\n"
										+"*****************************"
										+"\n"
										+ myGraph
										+"\n"
										+"*****************************");
						 /*  }else {
							   t4.setText(
									   "************************************************"
									   +"\n"
									   +"Cannot remove household: "+ name 
									   +"\n"
									   +"household is up-to-date with electricity bill"
									   +"\n"
									   +"*************************************************");
						   }
					   }*/
						  t9.getItems().clear();
						  for(int v =0;v<myGraph.getVertices().size();v++) {
								 t9.getItems().addAll(myGraph.getVertices().get(v).getValue());
							 }
				});
				//Edit household payment
				btn6.setOnAction(c-> {
		           String name = (String) c1.getValue();
		           int newPay = Integer.parseInt(t15.getText());
		           p.editVertex(myGraph, name, newPay);
		           t4.setText(
		        		   "***************************************************"
		        		   +"\n"
		        		   +"Household: " +name +" | "+ " new payment: R" +newPay
		        		   +"\n"
		        		   +"**************************************************"
		        		   +"\n"
		        		   +"Updated households"
		        		   +"\n"
		        		   +"***************************************************"
		        		   +"\n"
		        		   + myGraph
		        		   +"\n"
		        		   +"***************************************************");
		           t2.clear();
		           t3.clear();
				});
				//Add power supply
				btn8.setOnAction(c-> {
		          int cost = Integer.parseInt(t7.getText());
		          String from = (String) t8.getValue();
		          String to = (String) t9.getValue();
		          p.addEdges(myGraph, cost, from, to);
		          t10.setText(
		        		  "**********************************************************"
		        		  +"\n"
		        		  + "[Power supply added | Cost "
		        		  + "\n"
		        		  + myGraph.getEdges()
		        		  +"\n"
		        		  +"*********************************************************");
		          t7.clear();
				});
				//Cut power supply
				btn9.setOnAction(c-> {
					String from = (String) t8.getValue();
					String to = (String) t9.getValue();
					p.removeEdge(myGraph, from, to);
					t10.setText(
							"***********************************"
							+"\n"
							+ "Cut power for: " + to
							+"\n"
							+"**********************************"
							+"\n"
							+"Updated power supply"
							+"\n"
							+"**********************************"
							+"\n"
							+myGraph.getEdges()
							+"\n"
							+"**********************************");
		
				});
				//Draw new visual
				btn10.setOnAction(c-> {
					final int WH = 25;
					int mn = 20;
					int mx = 320;
					int mx2 =580;
					ArrayList<Integer> vsX = new ArrayList<>();
					ArrayList<Integer> vsY = new ArrayList<>();
						for(int v = 0; v < myGraph.getVertices().size();v++) {
							int locX = (int) (mn + Math.random() * (mx-mn));
							int locY =  (int) (mn + Math.random() * (mx2-mn));
								if(myGraph.getVertices().get(v).getValue().startsWith("P")) {
									gc2.setFill(Color.AQUA);
									gc2.fillOval(locX, locY, WH, WH);
									gc2.setStroke(Color.WHITE);
									gc2.strokeText(myGraph.getVertices().get(v).getValue() , locX, locY);
								}else {
									gc2.setFill(Color.CHOCOLATE);
									gc2.fillOval(locX, locY, WH, WH);
									gc2.setStroke(Color.WHITE);
									gc2.strokeText(myGraph.getVertices().get(v).getValue() +" | " + " R" + myGraph.getVertices().get(v).getWeight(), locX, locY);
								}   
								vsX.add(locX);
								vsY.add(locY);
						}
				});
				//Leave system
				btn11.setOnAction(c-> {
		           System.exit(0);
				});
			});
			
			//Leave system
			btn7.setOnAction(e -> {
				System.exit(0);
			});
			
		}
}
