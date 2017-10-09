﻿using Rhisis.World.Core.Components;
using System;
using System.Collections.Generic;

namespace Rhisis.World.Core.Entities
{
    /// <summary>
    /// Defines the entity behavior.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the entity id.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the list of the components attached to this entity.
        /// </summary>
        IReadOnlyCollection<IComponent> Components { get; }

        /// <summary>
        /// Gets the component of type passed as template parameter.
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        T GetComponent<T>() where T : IComponent;

        /// <summary>
        /// Adds a component to the entity.
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="component">Component to add</param>
        /// <returns>Component</returns>
        T AddComponent<T>(T component) where T : IComponent;

        /// <summary>
        /// Removes a component from the entity.
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="component">Component to remove</param>
        void RemoveComponent<T>(T component) where T : IComponent;

        /// <summary>
        /// Check if the component exists in the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool HasComponent<T>() where T : IComponent;
    }
}