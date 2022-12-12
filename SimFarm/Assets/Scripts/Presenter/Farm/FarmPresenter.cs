using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model.Animal;
using View.Farm;

namespace Presenter.Farm{
    public class FarmPresenter
    {
        private IFarmAnimal model;
        private FarmView view;
        private Animal[] animals;
        public FarmPresenter(FarmView View) {
            model = AnimalModel.Instance;
            view = View;
            view.createButton(model.getAnimalList());
        }


        


    }
}
