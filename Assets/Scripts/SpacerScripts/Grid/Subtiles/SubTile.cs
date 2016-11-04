using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    public delegate void TileStateEvent(SubTile tile, State newState);

    public abstract class SubTile
    {
        public Direction SubTileDirection = Direction.Up;
        public Type4 SubTileType = Type4.INTERIOR;
        public bool Flipped = false;
        public CollisionLayer SubTileCollision = CollisionLayer.ENTITY;
        public StatCollection SubTileStats = new StatCollection();

        public TileStateEvent TileActivated;
        public TileStateEvent TileEnabled;
        public TileStateEvent TileDamaged;

        protected State _active = State.IDLE;
        public State Active
        {
            get { return _active; }
            set
            {
                if (Enabled == State.ENABLED)
                {
                    if (value == State.ACTIVE)
                    {
                        _active = State.ACTIVE;
                        TileActivated(this, State.ACTIVE);
                    }
                    else if (value == State.IDLE)
                    {
                        _active = State.IDLE;
                        TileActivated(this, State.IDLE);
                    }
                    else
                        Debug.LogError("PS ERROR: " + value.ToString() + " is an invalid active state.");

                }
            }
        }

        protected State _enabled = State.ENABLED;
        public State Enabled
        {
            get { return _enabled; }
            set
            {
                if (value == State.ENABLED)
                {
                    if (DamageState != State.BROKEN || DamageState != State.DESTORYED)
                    {
                        _enabled = State.ENABLED;
                        TileEnabled(this, State.ENABLED);
                    }
                }
                else if (value == State.DISABLED)
                {
                    _enabled = State.DISABLED;
                    Active = State.IDLE;
                    TileEnabled(this, State.DISABLED);
                }
                else
                    Debug.LogError("PS ERROR: " + value.ToString() + " is an invalid enable state.");
            }
        }

        protected State _damageState = State.UNDAMAGED;
        public State DamageState
        {
            get { return _damageState; }
            set
            {
                switch (value)
                {
                    case State.UNDAMAGED:
                        _damageState = State.UNDAMAGED;
                        TileDamaged(this, State.UNDAMAGED);
                        break;
                    case State.DAMAGED:
                        _damageState = State.DAMAGED;
                        TileDamaged(this, State.DAMAGED);
                        break;
                    case State.BROKEN:
                        _damageState = State.BROKEN;
                        Enabled = State.DISABLED;
                        Active = State.IDLE;
                        TileDamaged(this, State.BROKEN);
                        break;
                    case State.DESTORYED:
                        _damageState = State.DESTORYED;
                        Enabled = State.DISABLED;
                        Active = State.IDLE;
                        TileDamaged(this, State.DESTORYED);
                        break;
                    default:
                        Debug.LogError("PS ERROR: " + value + " not a valid damage state.");
                        break;
                }
            }
        }

        public abstract MeshData GetSubTileMeshData();

    }
}


