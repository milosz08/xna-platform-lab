﻿namespace XnaZal4
{
    public class ModelEffectBinder<T>
    {
        private readonly T _model;
        private readonly GameSimpleEffect _effect;

        public ModelEffectBinder(T model, GameWindow game)
        {
            _model = model;
            _effect = new GameSimpleEffect(game);
        }

        public ModelEffectBinder(T model, GameWindow game, string assetName)
        {
            _model = model;
            _effect = new GameSimpleEffect(game, assetName);
        }

        public T Model
        {
            get => _model;
        }

        public GameSimpleEffect Effect
        {
            get => _effect;
        }
    }
}
