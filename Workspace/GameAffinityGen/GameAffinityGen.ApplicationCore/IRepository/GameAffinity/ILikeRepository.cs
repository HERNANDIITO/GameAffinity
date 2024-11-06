
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
    public partial interface ILikeRepository
    {
        void setSessionCP(GenericSessionCP session);

        LikeEN ReadOIDDefault(int id);

        void ModifyDefault(LikeEN like);

        System.Collections.Generic.IList<LikeEN> ReadAllDefault(int first, int size);



        void Modify(LikeEN like);


        void Destroy(int id);


        int New_(LikeEN like);

        LikeEN ReadOID(int id);


        System.Collections.Generic.IList<LikeEN> ReadAll(int first, int size);
    }
}
