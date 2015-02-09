using System;
using System.Collections.Generic;

namespace Engine {

  public class Actor {

    // contructors

    public Actor() {
      components = new Dictionary<string, Component>();
    }

    // components

    public void AddComponent(Component component) {
      if (component.name == "")
        throw new Exception("Component needs a name");

      if (components.ContainsKey(component.name))
        throw new Exception("Component already added");

      components.Add(component.name, component);
      component.Attached(this);
    }

    public bool HasComponent(string name) {
      return components.ContainsKey(name);
    }

    public Component GetComponent(string name) {
      return components[name];
    }

    public void RemoveComponent(string name) {
      components.Remove(name);
    }

    // events

    public void Update(float deltaTime) {
      foreach (KeyValuePair<string, Component> component in components)
        component.Value.Update(this, deltaTime);
    }

    public void Draw(Graphics graphics) {
      foreach (KeyValuePair<string, Component> component in components)
        component.Value.Draw(this, graphics);
    }

    // []

    public Component this[string name] {
      get {
        return GetComponent(name);
      }
    }

    // data

    private Dictionary<string, Component> components;

  }

}