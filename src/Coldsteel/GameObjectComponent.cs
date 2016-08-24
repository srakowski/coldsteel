using Coldsteel.Audio;
using Coldsteel.Input;
using Coldsteel.Physics;
using System.Collections.Generic;

namespace Coldsteel
{
    public class GameObjectComponent
    {
        /// <summary>
        /// Gets the game object this component is part of.
        /// </summary>
        public GameObject GameObject { get; internal set; }


        /// <summary>
        /// Gets any Tags assigned to the GameObject.
        /// </summary>
        protected string[] Tags => GameObject?.Tags;


        /// <summary>
        /// Gets access to the GameObject's GameObjectConfigurator.
        /// Use this to make common modifications to the GameObject.
        /// </summary>
        protected GameObjectConfigurator Set => GameObject?.Set;


        /// <summary>
        /// Gets access to the GameObject's GameObjectComponentAdder.
        /// Use this to add componets to the GameObject.
        /// </summary>
        protected GameObjectComponentAdder Add => GameObject?.Add;


        /// <summary>
        /// Gets the GameStateManager use to swap game states.
        /// </summary>
        protected GameStateManager State => GameObject?.State;


        /// <summary>
        /// Gets the ContentManager. Use to load or retrieve game content such as images or sounds.
        /// </summary>
        protected ContentManager Content => GameObject?.Content;


        /// <summary>
        /// Gets the GameStage, represents the window/view the world is rendered on.
        /// </summary>
        protected GameStage Stage => GameObject?.Stage;


        /// <summary>
        /// Gets the World. This is where all game objects live.
        /// </summary>
        protected World World => GameObject?.World;


        /// <summary>
        /// Gets the Camera used to look into to the World.
        /// </summary>
        protected Camera Camera => GameObject?.Camera;


        /// <summary>
        /// Gets the InputManager. Use this to evaluate controls.
        /// </summary>
        protected InputManager Input => GameObject?.Input;


        /// <summary>
        /// Gets the GameTime. Use this to make updates time independent.
        /// </summary>
        protected IGameTime GameTime => GameObject?.GameTime;


        /// <summary>
        /// Gets the Transform component assigned to the GameObject. 
        /// Defines the Position, Rotation, and Scale of the game object in the World.
        /// </summary>
        protected Transform Transform => GameObject?.Transform;


        /// <summary>
        /// Gets the Collider component assigned to the GameObject.
        /// A shape or fixture that may collide with other objects in the World.
        /// </summary>
        protected Collider Collider => GameObject?.Collider;


        /// <summary>
        /// Gets the RigidBody components assigned to the GameObject.
        /// Gives the GameObject physical properties that respond to forces such as gravity.
        /// </summary>
        protected RigidBody RigidBody => GameObject?.RigidBody;


        /// <summary>
        /// Gets the AudioSource component assigned to the GameObject.
        /// Used to emit audio sound effects.
        /// </summary>
        protected AudioSource AudioSource => GameObject?.AudioSource;


        /// <summary>
        /// Gets the Behavior components assigne to the GameObject.
        /// These are user defined classes that drive the behavior of the GameObject.
        /// </summary>
        protected IEnumerable<Behavior> Behaviors => GameObject?.Behaviors;


        /// <summary>
        /// Kills the GameObject and all its children.
        /// </summary>
        protected void Kill() => GameObject?.Kill();


        /// <summary>
        /// Called after the GameObject is assigned and this component
        /// has access to everything it may need to do stuff.
        /// </summary>
        public virtual void Initialize() { }


        /// <summary>
        /// Called if the Component is about to be removed from the GameObject.
        /// </summary>
        public virtual void Dispose() { }


        /// <summary>
        /// Called when the GameObject is updated.
        /// </summary>
        public virtual void Update() { }
    }
}
