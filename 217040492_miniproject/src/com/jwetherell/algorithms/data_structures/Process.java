/**
 * 
 */
package com.jwetherell.algorithms.data_structures;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collection;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Random;
import java.util.StringTokenizer;

import com.jwetherell.algorithms.data_structures.Graph.Edge;
import com.jwetherell.algorithms.data_structures.Graph.Vertex;

/**
 * @author csakh
 *
 */
public class Process<T extends Comparable<T>>  {
	
 
    public Process() {}
    
    //Create Vertices based on information read from file
	@SuppressWarnings("unchecked")
	public  Collection<Vertex<T>> readVfile(){
		//Declare local variables
		Collection<Vertex<T>> households = new ArrayList<Vertex<T>>();
		InputStream input = getClass().getResourceAsStream("info.txt");
	    BufferedReader bin = new BufferedReader(new InputStreamReader(input));
		//read file
		try {
			String data = "";
			while((data = bin.readLine())!=null) {
				
				    StringTokenizer st = new StringTokenizer(data,",");
				    T hhName =  (T) st.nextToken();
					int payed = Integer.parseInt(st.nextToken());
					System.out.println("Vertex Name: " + hhName + " Units Payed: " + " R" + payed);
					Vertex<T> v = new Vertex<>(hhName,payed);
					households.add(v);
			}
		
		} catch (Exception e) {
			e.printStackTrace();
		} 
		return households;
		
	}
	
	//Return created vertices and use them to create edges
	public  Collection<Edge<T>> createEdge(){
		//Declare local variables
		Collection<	Edge<T>> access = new ArrayList<Edge<T>>();
		Collection<	Vertex<T>> houses = readVfile();
		Random random = new Random();
		int mn = 5;
		int bn =6;
		int mx =7;
		//loop through array of vertices
		for(int x = 0; x < houses.size();x++) {
			int costs =0;
			Vertex<T> from =null;
			Vertex<T> to =null;
			if(x < 1) {
				costs = random.nextInt(2000);
			    from = ((ArrayList<Vertex<T>>) houses).get(7);
				to = ((ArrayList<Vertex<T>>) houses).get(x);
			}else if(x==1) {
				costs = random.nextInt(2000);
			    from = ((ArrayList<Vertex<T>>) houses).get(7);
				to = ((ArrayList<Vertex<T>>) houses).get(x);
			}else if(x==2) {
				costs = random.nextInt(2000);
			    from = ((ArrayList<Vertex<T>>) houses).get(6);
				to = ((ArrayList<Vertex<T>>) houses).get(x);
			}else if(x==3) {
				costs = random.nextInt(2000);
			    from = ((ArrayList<Vertex<T>>) houses).get(6);
				to = ((ArrayList<Vertex<T>>) houses).get(x);
			}
			else if(x==4) {
				costs = random.nextInt(2000);
			    from = ((ArrayList<Vertex<T>>) houses).get(5);
				to = ((ArrayList<Vertex<T>>) houses).get(x);
			}else if(x==mn) {
				costs = random.nextInt(2000);
				from = ((ArrayList<Vertex<T>>) houses).get(x);
				to = ((ArrayList<Vertex<T>>) houses).get(bn);
			}else if(x==bn) {
				costs = random.nextInt(2000);
				from = ((ArrayList<Vertex<T>>) houses).get(x);
				to = ((ArrayList<Vertex<T>>) houses).get(mx);
			}else if(x==mx) {
				costs = random.nextInt(2000);
				from = ((ArrayList<Vertex<T>>) houses).get(x);
				to = ((ArrayList<Vertex<T>>) houses).get(mn);
			}
			
			
			Edge<T> e = new Edge<>(costs,from,to);
			System.out.println("new edge: " + e);
			access.add(e);
		}
		return access;
		
	}
	
	//Create graph using available vertices and edges
	public Graph<T> createGraph(Collection<Vertex<T>> Vs,Collection<Edge<T>> Es){
		Graph<T> G = new Graph<>(Vs,Es);
		System.out.println("Graph is created");
		return G;
		
	}
   	
	// Add household (vertex)
	public void addVertex(Graph<T> G,T name,int payed) {
		Vertex<T> newVertex = new Vertex<>(name,payed);
		G.getVertices().add(newVertex);
	}
	
	//Add power supply as an (edge) between household vertex and Pole vertex 
	public void addEdges(Graph<T> G,int costs,T nameFrom,T nameTo) {
		Vertex<T> from = null;
		Vertex<T> to = null;
		for(int v = 0;v < G.getVertices().size();v++) {
			if(G.getVertices().get(v).getValue().equals(nameFrom)) {
				from = G.getVertices().get(v);
			}
			else if(G.getVertices().get(v).getValue().equals(nameTo)) {
				to = G.getVertices().get(v);
			}
		}
		Edge<T> newEdge = new Edge<>(costs,from,to);
		G.getEdges().add(newEdge);
	}
	
	//Edit household units payed(weight)
	public void editVertex(Graph<T> G,T name ,int payed){
		for(int v = 0;v<G.getVertices().size();v++) {
			if(G.getVertices().get(v).getValue().equals(name)) {
				G.getVertices().get(v).setWeight(payed);
			}
		}	
	}
	
	//Edit power supply (edge), give new cost and locations
	public void editEdge(Graph<T> G,int oldCosts,int newCosts) {
		for(int e = 0;e<G.getEdges().size();e++) {
			if(G.getEdges().get(e).getCost() == oldCosts) {
				G.getEdges().get(e).setCost(newCosts);
			}
		}
	}
	
	//Remove household (vertex)
	public void removeVertex(Graph<T> G,T name) {
		for(int v =0;v<G.getVertices().size();v++) {
			if(G.getVertices().get(v).getValue().equals(name)) {
				G.getVertices().remove(v);
			}
		}
		
	}
	
	//Remove power supply (edge)
	public void removeEdge(Graph<T> G,T nameFrom,T nameTo) {
		for(int e = 0;e < G.getEdges().size();e++) {
			if(G.getEdges().get(e).getFromVertex().getValue().equals(nameFrom) && G.getEdges().get(e).getToVertex().getValue().equals(nameTo)) {
				G.getEdges().remove(e);
			}
		}
	}
	
	//Visit every household (vertex)
	public ArrayList<Vertex<T>> BFTraverse(Graph<T> G,Vertex<T> begin){
			ArrayList<Vertex<T>> seen = new ArrayList<Vertex<T>>();
			Queue<Vertex<T>> queue = new LinkedList<Vertex<T>>();
			queue.add(begin);
			while(!queue.isEmpty()) {
				Vertex<T> house = queue.poll();
				for(int v =0;v < G.getVertices().size();v++) {
					if(!house.getValue().equals(G.getVertices().get(v).getValue())) {
						if(!seen.contains(G.getVertices().get(v))) {
							seen.add(G.getVertices().get(v));
							queue.add(G.getVertices().get(v));
						}
					}
				}
			}
			return seen;
		}
	
}
