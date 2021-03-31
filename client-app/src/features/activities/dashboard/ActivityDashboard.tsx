import React from 'react';
import { Grid } from 'semantic-ui-react';
import { Activity } from '../../../app/Models/Activity';
import ActivityDetails from '../details/ActivitiesDetails';
import ActivityForm from '../form/ActivityForm';
import ActivityList from './ActivityList';

interface Props { // this is <ActivityDashboard ***activities={input}*** />
    activities: Activity[];
    selectedActivity: Activity | undefined;
    selectActivity: (id: string) => void;
    cancelSelectActivity: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
    createOrEdit: (activity: Activity) => void;
    deleteActivity: (id: string) => void;
}

export default function ActivityDashboard({activities, selectedActivity, deleteActivity,
        selectActivity, cancelSelectActivity, editMode, openForm, closeForm, createOrEdit}: Props) { //destructures Props
    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList
                    activities={activities}
                    selectActivity={selectActivity}
                    deleteActivity={deleteActivity}/>
            </Grid.Column>
            <Grid.Column width='6'> {/*semantic grids have 16 columns so 10 and 6 is full*/}
                {selectedActivity && !editMode &&
                <ActivityDetails
                    activity={selectedActivity}
                    cancelSelectActivity={cancelSelectActivity}
                    openForm={openForm}
                />}
                {editMode &&
                <ActivityForm closeForm={closeForm} activity={selectedActivity} createOrEdit={createOrEdit}/>}
            </Grid.Column>
        </Grid>
    )
}