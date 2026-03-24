Unity Clean Architecture Melee Combat System

A modular and cleanly structured melee combat system built in Unity.  
This project focuses on architecture and system design rather than full gameplay implementation.

Features

Melee attack system

Health and damage handling

Death logic

2D and 3D detection support

New Input System integration

Unity-independent domain layer

Architecture

Core (Domain) → Pure C# combat logic (Health, Damage, Interfaces)

UseCases (Application) → Attack flow and damage processing

Detection → 2D / 3D target detection abstraction

Unity (Presentation) → Input, MonoBehaviour scripts, scene integration

All combat rules (damage, health, death) are separated from Unity-specific code.

Technical Highlights

Layered clean architecture (Domain + Application + Presentation)

IDamageable abstraction for loose coupling

Swappable detection system (2D / 3D)

Adapter layer for Unity ↔ Domain communication

Event-driven input handling (New Input System)

Simple and extensible structure without over-engineering
