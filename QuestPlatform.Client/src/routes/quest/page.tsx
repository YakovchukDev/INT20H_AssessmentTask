import {FC} from "react";
import {Box, Button, Container, Stack, Typography} from "@mui/material";
import * as styles from "./quest.styles.ts";
import Card from "../../lib/components/styled/Card.tsx";
import QuestCard from "../../layout/quest-card/component/card/QuestCard.tsx";
import {useNavigate} from "react-router";

const QuestPage:FC = () => {
    const navigate = useNavigate();

    return (
        <Box sx={styles.container}>
            <Container sx={styles.content}>
                <Card sx={{width:'100%', alignItems:'flex-start'}}>
                    <Box display={'flex'} flexDirection={'column'} gap={'20px'}>
                        <Box sx={{display:'flex', flexDirection:'column', alignItems:'flex-start'}}>
                            <QuestCard zoomed={false}/>
                        </Box>
                        <Typography>
                            Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident.
                        </Typography>
                        <Stack gap={'10px'} direction={'row-reverse'}>
                            <Button onClick={()=>navigate('/game/0')}>Грати</Button>
                        </Stack>
                    </Box>
                </Card>
            </Container>
        </Box>
    )
}

export default QuestPage;