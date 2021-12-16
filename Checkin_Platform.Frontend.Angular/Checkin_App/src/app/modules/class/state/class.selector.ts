import { createFeatureSelector, createSelector } from "@ngrx/store";
import { classAdapter, ClassState } from "./class.reducer";


const getClassFeatureState = createFeatureSelector<ClassState>(
    "class"
  );
  
  export const getClasses = createSelector(
    getClassFeatureState,
    classAdapter.getSelectors().selectAll
  );
  
  export const getClassesLoading = createSelector(
    getClassFeatureState,
    (state: ClassState) => state.loading
  );
  
  export const getClassesLoaded = createSelector(
    getClassFeatureState,
    (state: ClassState) => state.loaded
  );
  
  export const getError = createSelector(
    getClassFeatureState,
    (state: ClassState) => state.error
  );
  
  export const getCurrentClassId = createSelector(
    getClassFeatureState,
    (state: ClassState) => state.selectedClassId
  );
  
  export const getCurrentClass = createSelector(
      getClassFeatureState,
      getCurrentClassId,
      (state: ClassState)  => (state.selectedClassId != null ? state.entities[state.selectedClassId] : null)
    );