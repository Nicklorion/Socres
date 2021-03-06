﻿namespace Socres.Web.Mvc.Tests.SpecimenBuilders
{
    using System.Collections;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using FakeItEasy;
    using Ploeh.AutoFixture.Kernel;
    using Socres.FakingEasy.AutoFakeItEasy.SpecimenBuilders.Base;

    /// <summary>
    /// SpecimenBuilder that creates a <see cref="ActionExecutingContext"/>
    /// </summary>
    public class ActionExecutingContextSpecimenBuilder : SpecimenBuilderBase
    {
        /// <summary>
        /// Creates a new <see cref="ActionExecutingContext"/> specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        /// The requested specimen if possible; otherwise a <see cref="T:Ploeh.AutoFixture.Kernel.NoSpecimen" /> instance.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <remarks>
        ///   <para>
        /// The <paramref name="request" /> can be any object, but will often be a
        ///   <see cref="T:System.Type" /> or other <see cref="T:System.Reflection.MemberInfo" /> instances.
        ///   </para>
        ///   <para>
        /// Note to implementers: Implementations are expected to return a
        ///   <see cref="T:Ploeh.AutoFixture.Kernel.NoSpecimen" /> instance if they can't satisfy the request.
        ///   </para>
        /// </remarks>
        public override object Create(object request, ISpecimenContext context)
        {
            if (!IsRequestForType(request, typeof(ActionExecutingContext)))
            {
                return new NoSpecimen(request);
            }

            var controller = (Controller)context.Resolve(typeof(Controller));
            var actionDescriptor = (ActionDescriptor) context.Resolve(typeof (ActionDescriptor));

            var actionExecutingContext = A.Fake<ActionExecutingContext>();
            actionExecutingContext.Controller = controller;
            actionExecutingContext.ActionDescriptor = actionDescriptor;

            return actionExecutingContext;
        }
    }
}
